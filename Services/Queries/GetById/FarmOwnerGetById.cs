using AutoMapper;
using CORE.Exceptions;
using Repositories.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Queries.GetById
{
    public class FarmOwnerGetById : IGetByIdDerivedTypes
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;

        public FarmOwnerGetById(IRepositoryManager manager, IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }
        public async Task<UserForReturnDto> GetById(Guid id, bool track)
        {
           var FarmOwnerEntity=await manager.farmOwner.GetFarmOwnerById(id, track);
            
            if (FarmOwnerEntity is null)
                throw new UserNotFoundException(id);

            return mapper.Map<FarmOwnerForReturnDto>(FarmOwnerEntity);
        }
    }
}
