using AutoMapper;
using CORE.Contracts;
using CORE.Exceptions;
using CORE.Models;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public sealed class DiseaseService:IDiseaseService
    {
        private readonly IRepositoryManager manager;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;

        public DiseaseService(IRepositoryManager manager,ILoggerManager logger,IMapper mapper) {
            this.manager = manager;
            this.logger = logger;
            this.mapper = mapper;
        }

        public DiseaseDto Create(DiseaseForCreationDto dto)
        {
            var Entity = mapper.Map<FishDisease>(dto);
            manager.Diseases.Create(Entity);
            manager.Save();

            var Res=mapper.Map<DiseaseDto>(Entity);
            return Res;
        }


        //public DiseaseForUpdatingDto Create(DiseaseForCreationDto dto)
        //{
        //    var FSD = mapper.Map<FishDisease>(dto);
        //    manager.Diseases.Create(FSD);
        //    manager.Save();
        //    var Res=  mapper.Map<DiseaseForUpdatingDto>(FSD);
        //    return Res;
        //}

        public IEnumerable<DiseaseDto> GetALLDisease(bool track)
        {
            var all = manager.Diseases.GetAll(track);

            var Res= mapper.Map<IEnumerable<DiseaseDto>>(all);
            return Res;
        }

        public DiseaseDto GetDisease(int id, bool track)
        {
            var FDisease= manager.Diseases.GetDisease(id, track);
            
            if(FDisease is null )
              throw new DiseaseNotFoundException(id);

            var DiseaseDTO = mapper.Map<DiseaseDto>(FDisease);

            return DiseaseDTO;
        }

        
    }
}
