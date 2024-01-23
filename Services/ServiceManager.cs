using AutoMapper;
using CORE.Contracts;
using Repositories.Contracts;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDiseaseService> disease;
        private readonly Lazy<IDetectDiseaseService> detectDisease;


        public ServiceManager(IRepositoryManager manager,ILoggerManager logger,IMapper mapper)
        {
            disease=new Lazy<IDiseaseService>(()=>new DiseaseService(manager, logger,mapper));
            detectDisease=new Lazy<IDetectDiseaseService>(() =>new DetectDiseaseService(manager,logger,mapper));
        }

        public IDiseaseService diseaseService => disease.Value;
        public IDetectDiseaseService detectDiseaseService =>detectDisease.Value;
    }
}
