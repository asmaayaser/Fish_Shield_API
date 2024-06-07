using AutoMapper;
using CORE.Contracts;
using CORE.Exceptions;
using CORE.Models;
using CORE.Shared;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;

namespace Services
{
    public sealed class DiseaseService:IDiseaseService
    {
        private readonly IRepositoryManager manager;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IIOService ioService;
        private readonly IHttpContextAccessor httpContextAccessor;

        public DiseaseService(IRepositoryManager manager,ILoggerManager logger,IMapper mapper,IIOService ioService,IHttpContextAccessor httpContextAccessor) {
            this.manager = manager;
            this.logger = logger;
            this.mapper = mapper;
            this.ioService = ioService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<DiseaseDto> Create(DiseaseForCreationDto dto)
        {
            var Entity = mapper.Map<FishDisease>(dto);
            manager.Diseases.Create(Entity);
           await manager.SaveAsync();
           var RelativePath= await ioService.uploadImage("Images/Diseases",dto.PhotoPath ,$"{Entity.ID}");
            var PathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{RelativePath}";
            Entity.PhotoPath = PathToStoredInDB;
           await manager.SaveAsync();
            var Res=mapper.Map<DiseaseDto>(Entity);
            return Res;
        }


        

        public (IEnumerable<DiseaseDto> diseases, MetaData meta) GetALLDisease(FishDiseaseParameters fishDiseaseParameters, bool track)
        {
            var allwithMeta = manager.Diseases.GetAll(fishDiseaseParameters,track);

            var Res= mapper.Map<IEnumerable<DiseaseDto>>(allwithMeta);
            return (diseases:Res,meta:allwithMeta.MetaInfo);
        }

		public (IEnumerable<DiseaseDto> diseases, MetaData meta) GetALLDiseasePartial(FishDiseaseParameters fishDiseaseParameters, bool track)
		{
			var allwithMeta = manager.Diseases.GetAllPartial(fishDiseaseParameters, track);

			var Res = mapper.Map<IEnumerable<DiseaseDto>>(allwithMeta);
			return (diseases: Res, meta: allwithMeta.MetaInfo);
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
