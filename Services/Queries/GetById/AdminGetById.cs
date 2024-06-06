using AutoMapper;
using CORE.Exceptions;
using Repositories.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Queries.GetById
{
    public class AdminGetById : IGetByIdDerivedTypes
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;
        public AdminGetById(IRepositoryManager manager, IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }

        public async Task<UserForReturnDto> GetById(Guid id, bool track)
        {
          var AdminEntity= await manager.Admins.GetAdminById(id, track);
            if(AdminEntity is null)
                throw new UserNotFoundException(id);
            return mapper.Map<AdminForReturnDto>(AdminEntity);
        }
    }
}
