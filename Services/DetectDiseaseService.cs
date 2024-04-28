using AutoMapper;
using CORE.Contracts;
using CORE.Exceptions;
using CORE.Models;
using CORE.Shared;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;
using System.Net.Http.Json;

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


        public async Task<DetectDto> CreateDetection(string OwnerId,IFormFile detectImage)
        {
           var farmowner= await EnsurePrincipleIsExists(Guid.Parse(OwnerId));

            if (farmowner.HasFreeTrialCount > 0)
            {
                // decrement count 1
                 farmowner.HasFreeTrialCount--;
                // do detection
                return await DoDetection();
            }else if(farmowner.isPaid && farmowner.SubscriptionEndDate >  DateTime.Now) 
            {
               return await DoDetection();
            }
            else
            {
                farmowner.isPaid = false;
                throw new SubscriptionEndedException();
            }

            async Task<DetectDto> DoDetection()
            {
                var ImagePath = await ioService.uploadImage($"Images/Detects/{OwnerId}", detectImage, Guid.NewGuid().ToString());
                var PathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{ImagePath}";
                var PathForConsuming = $"{webHostEnvironment.WebRootPath}{ImagePath}";

                var Result = /*await MakeApiCallToMLTeamModel(PathForConsuming) ?? */ConsumeMLModel(PathForConsuming);
                var Disease = manager.Diseases.GetDiseaseByName(Result.dname, track: false);
                var Entity = manager.DetectDisease.Create(OwnerId, new DetectDisease() { FishPhoto = PathToStoredInDB, NameOfDisFromAIModel = Result.dname, Score = Result.score, DiseaseId = Disease.ID });
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

        private async Task<string> MakeApiCallToMLTeamModel(string imagePath)
        {
            string? diseaseName = null;
            using (var http = new HttpClient())
            {
                using (var imageStream = File.OpenRead(imagePath))
                {
                    var content = new MultipartFormDataContent();
                    content.Add(new StreamContent(imageStream));
                    http.BaseAddress = new Uri(configuration["External_Detect_Api:DetectBaseUrl"]);
                    var response = await http.PostAsync(configuration["External_Detect_Api:DetectEndPoint"], content);
                    if (response.IsSuccessStatusCode)
                        diseaseName = await response.Content.ReadAsStringAsync();
                }
            }
            return diseaseName;
        }

        private async Task<FarmOwner> EnsurePrincipleIsExists(Guid ownerId)
        {
           var isexists=await manager.farmOwner.GetFarmOwnerById(ownerId,track:true);
            if (isexists == null)
                throw new UserNotFoundException(ownerId);
            return isexists;
        }
    }
}
