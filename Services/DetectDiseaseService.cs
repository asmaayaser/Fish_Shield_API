using AutoMapper;
using CORE.Contracts;
using CORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;

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

        public DetectDiseaseService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper,IIOService ioService,IHttpContextAccessor httpContextAccessor,IWebHostEnvironment webHostEnvironment) { 
        
            manager = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.ioService = ioService;
            this.httpContextAccessor = httpContextAccessor;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task<DetectDto> CreateDetection(string OwnerId,IFormFile detectImage)
        {
            var ImagePath=  await  ioService.uploadImage($"Images/Detects/{OwnerId}", detectImage, Guid.NewGuid().ToString());
            var PathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{ImagePath}";

            var PathForConsuming= $"{webHostEnvironment.WebRootPath}{ImagePath}";
           var Result= ConsumeMLModel(PathForConsuming);
            var Disease = manager.Diseases.GetDiseaseByName(Result,track: false);

           var Entity= manager.DetectDisease.Create(OwnerId, new DetectDisease() { FishPhoto = PathToStoredInDB, NameOfDisFromAIModel = Result, DiseaseId = Disease.ID});
            await manager.SaveAsync();
            Entity.Disease = Disease;
           return mapper.Map<DetectDto>(Entity);
         
        }

        private string ConsumeMLModel(string imagePath)
        {
            //Load sample data
            var imageBytes = File.ReadAllBytes(imagePath);
            MLModelFromBackend.ModelInput sampleData = new MLModelFromBackend.ModelInput()
            {
                ImageSource = imageBytes,
            };

            //Load model and predict output
           return MLModelFromBackend.Predict(sampleData).PredictedLabel;
        }
    }
}
