using AutoMapper;
using CORE.Contracts;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public sealed class DetectDiseaseService : IDetectDiseaseService
    {
        public readonly IRepositoryManager manager;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;

        public DetectDiseaseService(IRepositoryManager repository,ILoggerManager logger,IMapper mapper) { 
        
            manager = repository;
            this.logger = logger;
            this.mapper = mapper;
        }

      
    }
}
