using AutoMapper;
using Repositories.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Queries.GetAll
{
    public class GetAllDoctors : IGetAllDerivedTypes
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;

        public GetAllDoctors(IRepositoryManager manager, IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }
        public async Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track)
        {
            var AllDoctorsEntities = await manager.Doctors.GetAllDoctors(track);

            return mapper.Map<IEnumerable<DoctorForReturnDto>>(AllDoctorsEntities);
        }
    }
}
