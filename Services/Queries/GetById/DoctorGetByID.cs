using AutoMapper;
using CORE.Exceptions;
using CORE.Models;
using Repositories.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Queries.GetById
{
    public class DoctorGetByID : IGetByIdDerivedTypes
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;

        public DoctorGetByID(IRepositoryManager manager, IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }
        public async Task<UserForReturnDto> GetById(Guid id, bool track)
        {
            var DoctorEntityFromDB = await manager.Doctors.GetDoctorById(id, track);

            if (DoctorEntityFromDB is null)
                throw new UserNotFoundException(id);

            return mapper.Map<DoctorForReturnDto>(DoctorEntityFromDB);
        }
    }
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
