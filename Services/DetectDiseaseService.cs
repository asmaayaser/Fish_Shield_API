using AutoMapper;
using CORE.Contracts;
using CORE.Exceptions;
using CORE.Models;
using CORE.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.InteropServices;
using System.Runtime.Serialization;
using System.Text.Json;

namespace Services
{
    public sealed class DetectDiseaseService : IDetectDiseaseService
    {
        public readonly IRepositoryManager manager;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IIOService ioService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IConfiguration configuration;

        public DetectDiseaseService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper,IIOService ioService,IHttpContextAccessor httpContextAccessor,IWebHostEnvironment webHostEnvironment,IConfiguration configuration) { 
        
            manager = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.ioService = ioService;
            this.httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
            this.configuration = configuration;
        }


        public async Task<DetectDto> CreateDetection(string userId,IFormFile detectImage)
        {
           var userAccount= await EnsurePrincipleIsExists(Guid.Parse(userId));
            
            if (userAccount.Discriminator.Equals("doctor", StringComparison.OrdinalIgnoreCase))
                 return   mapper.Map<DetectDto>(await MakeApiCallToMLTeamModel(detectImage,userId)) /*await DoDetection()*/;
            else if (userAccount.HasFreeTrialCount > 0)
            {
                // decrement count 1
                 userAccount.HasFreeTrialCount--;
                // do detection
                return mapper.Map<DetectDto>(await MakeApiCallToMLTeamModel(detectImage, userId)) /*await DoDetection()*/;
            }else if(userAccount.isPaid && userAccount.SubscriptionEndDate >  DateTime.Now) 
            {
               return mapper.Map<DetectDto>(await MakeApiCallToMLTeamModel(detectImage, userId)) /*await DoDetection()*/;
            }
            else
            {
                userAccount.isPaid = false;
                await manager.SaveAsync();
                throw new SubscriptionEndedException();
            }

            async Task<DetectDto> DoDetection()
            {
                var ImagePath = await ioService.uploadImage($"Images/Detects/{userId}", detectImage, Guid.NewGuid().ToString());
                var PathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{ImagePath}";
                var PathForConsuming = $"{webHostEnvironment.WebRootPath}{ImagePath}";

                var Result = /*await MakeApiCallToMLTeamModel(PathForConsuming) ?? */ConsumeMLModel(PathForConsuming);
                var Disease = manager.Diseases.GetDiseaseByName(Result.dname, track: false);
                var Entity = manager.DetectDisease.Create(userId, new DetectDisease() { FishPhoto = PathToStoredInDB, NameOfDisFromAIModel = Result.dname, Score = Result.score, DiseaseId = Disease.ID });
                await manager.SaveAsync();
                Entity.Disease = Disease;
                return mapper.Map<DetectDto>(Entity);
            }


            
        }

        public async Task<ReportDto> GenerateReport(string OwnerId, DetectionReportParameters detectionReportParameters)
        {
            if (!detectionReportParameters.IsValidDateRange)
                throw new InvalidDateRangeBadRequest();
            await EnsurePrincipleIsExists(Guid.Parse(OwnerId));
            var Report=await manager.DetectDisease.GetReportAnalysis(OwnerId,detectionReportParameters);
            return Report;
        }

        private (string dname,float score)  ConsumeMLModel(string imagePath)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(imagePath);
            MLModelFromBackend.ModelInput sampleData = new MLModelFromBackend.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output

            var prediction= MLModelFromBackend.Predict(sampleData);
            var diseaseName= prediction.PredictedLabel;
            var Accuracy = prediction.Score.Max() * 100;
            return (dname: diseaseName, score: Accuracy);
        }

        private async Task<DetectDisease> MakeApiCallToMLTeamModel(IFormFile image,string userId)
        {
           
          

                using (var client = new HttpClient())
                {
                    using (var content = new MultipartFormDataContent())
                    {
                        using (var stream = new MemoryStream())
                        {
                            await image.CopyToAsync(stream);
                            var fileContent = new ByteArrayContent(stream.ToArray());
                            fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse(image.ContentType);

                            content.Add(fileContent, "image", image.FileName);

                            var response = await client.PostAsync(configuration["External_Detect_Api:DetectEndPoint"], content);
                            if (!response.IsSuccessStatusCode)
                            {
                                throw new FlaskApiCallDetectionException("Error from Flask API");
                            }

                            var jsonResponse = await response.Content.ReadAsStringAsync();
                            var result = JsonSerializer.Deserialize<DetectionResult>(jsonResponse);
                            if (result is null)
                            {
                                logger.LogError($"Failed To Desirialize this Object:{jsonResponse}");
							    throw new FailedToDeserializeResponseException();
						    }
                            if(result.Detection.Contains("No Detections",StringComparison.OrdinalIgnoreCase))
                            {
                                    throw new NoFishDetectedInImageBadRequestException();
                            }
						// Convert base64 string to image and save to wwwroot/detects
						   var base64Image = result.image;
                            var imagePath = SaveBase64Image(base64Image, Path.GetExtension(image.FileName),userId);

                        var Desease = manager.Diseases.GetDiseaseByName(result.Detection, track: false);
                        if(Desease is null )
                        {
                            throw new DiseaseNotFoundException(result.Detection);
                        }
						var PathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{imagePath}";
						var detection=  manager.DetectDisease.Create(userId,new DetectDisease() 
                            { 
                                DateTime=DateTime.Now, 
                                NameOfDisFromAIModel = result.Detection,
                                Score=result.Percentage,
                                FishPhoto=PathToStoredInDB,
                                DiseaseId=Desease.ID,
                            });    
                            await manager.SaveAsync();

                        detection.Disease = manager.Diseases.GetDisease(detection.DiseaseId??0, track: false);
                            return detection ;
                        }
                    }
                
            }
           
        }
		private string SaveBase64Image(string base64Image, string extension,string userId)
		{
			var fileName = $"{Guid.NewGuid()}{extension}";
			var filePath = Path.Combine(webHostEnvironment.WebRootPath, $"images/Detects/{userId}", fileName);
			var bytes = Convert.FromBase64String(base64Image);
			using (var imageFile = new FileStream(filePath, FileMode.Create))
			{
				imageFile.Write(bytes, 0, bytes.Length);
				imageFile.Flush();
			}
            string partialPath = $"/images/Detects/{userId}/{fileName}";
			return partialPath;
		}
		private async Task<PaymentUserAccount> EnsurePrincipleIsExists(Guid userid)
        {
           var isexists=await manager.PaymentUserRepository.GetPaymentUserAccountById(userid,track:true);
            if (isexists == null)
                throw new UserNotFoundException(userid);
            return isexists;
        }

	
	}
}
