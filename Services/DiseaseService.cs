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

        public IEnumerable<DiseaseForManipulationDto> GetALLDisease(bool track)
        {
            var all = manager.Diseases.GetAll(track);

            var Res= mapper.Map<IEnumerable<DiseaseForManipulationDto>>(all);
            return Res;
        }

        public DiseaseForManipulationDto GetDisease(int id, bool track)
        {
            var FDisease= manager.Diseases.GetDisease(id, track);
            
            if(FDisease is null )
              throw new DiseaseNotFoundException(id);

            var DiseaseDTO = mapper.Map<DiseaseForManipulationDto>(FDisease);

            return DiseaseDTO;
        }
    }
}
