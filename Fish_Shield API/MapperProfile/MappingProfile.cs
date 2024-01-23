using AutoMapper;
using CORE.Models;
using Services.DTO;

namespace Fish_Shield_API.MapperProfile
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<FishDisease, DiseaseForManipulationDto>();
        }
    }

}
