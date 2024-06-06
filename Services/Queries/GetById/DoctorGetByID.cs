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
}
