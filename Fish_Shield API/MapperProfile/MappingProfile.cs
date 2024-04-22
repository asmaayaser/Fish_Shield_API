using AutoMapper;
using CORE.Models;
using Services.DTO;

namespace Fish_Shield_API.MapperProfile
{
    public class MappingProfile:Profile
    {
      

        public MappingProfile()
        {
            

            CreateMap<FishDisease, DiseaseDto>()
                .ForMember(d => d.CausativeAgents, opt => opt.MapFrom(x => x.CausativeAgents.Select(d => d.Agents)))
                .ForMember(d => d.ImpactOnAquacultures, opt => opt.MapFrom(x => x.ImpactOnAquacultures.Select(d => d.ImpactOnAquaculturee)))
                .ForMember(d => d.ClinicalSigns, opt => opt.MapFrom(x => x.ClinicalSigns.Select(d => d.Sign)))
                .ForMember(d => d.Treatment, opt => opt.MapFrom(d => d.Treatment.Select(d => d.TreatmentDesc)))
                .ForMember(d => d.Diagnosis, opt => opt.MapFrom(d => d.Diagnosis.Select(d => d.Diagones)))
                .ForMember(d => d.PreventionAndControlls, opt => opt.MapFrom(d => d.PreventionAndControlls.Select(d => d.Prevention)))
                .ForMember(d => d.RecommandationActions, opt => opt.MapFrom(d => d.RecommandationActions.Select(d => d.Action)));


            CreateMap<DiseaseForCreationDto, FishDisease>()
                .ForMember(d => d.CausativeAgents, opt => opt.MapFrom(src => src.CausativeAgents.Select(s => new CausativeAgents { Agents = s }).ToList()))
                .ForMember(d => d.ImpactOnAquacultures, opt => opt.MapFrom(src => src.ImpactOnAquacultures.Select(s => new ImpactOnAquaculture { ImpactOnAquaculturee = s }).ToList()))
                .ForMember(d => d.ClinicalSigns, opt => opt.MapFrom(src => src.ClinicalSigns.Select(s => new ClinicalSigns { Sign = s }).ToList()))
                .ForMember(d => d.Treatment, opt => opt.MapFrom(src => src.Treatment.Select(s => new Treatment { TreatmentDesc = s }).ToList()))
                .ForMember(d => d.Diagnosis, opt => opt.MapFrom(src => src.Diagnosis.Select(s => new Diagnosis { Diagones = s }).ToList()))
                .ForMember(d => d.PreventionAndControlls, opt => opt.MapFrom(src => src.PreventionAndControlls.Select(s => new PreventionAndControll { Prevention = s }).ToList()))
                .ForMember(d => d.RecommandationActions, opt => opt.MapFrom(src => src.RecommandationActions.Select(s => new RecommandationActions { Action = s }).ToList()))
                .ForMember(d=>d.PhotoPath,opt=>opt.Ignore());


            CreateMap<DetectDisease, DetectDto>();



            CreateMap<FarmOwnerForRegistrationDto, FarmOwner>();
            CreateMap<DoctorForRegistrationDto, Doctor>().ForMember(d=>d.PersonalPhoto,s=>s.Ignore());
            CreateMap<AdminForRegistrationDto, Admin>().ForMember(d => d.PersonalPhoto, s => s.Ignore());

            CreateMap<Doctor, DoctorForReturnDto>();
            CreateMap<Admin,AdminForReturnDto>();
            CreateMap<FarmOwner, FarmOwnerForReturnDto>();
            CreateMap<AppUser, AppuserForReturnPartial>();

            CreateMap<FeedbackForCreationDto, FeedBack>();
            CreateMap<FeedBack,FeedbackForReturnDto>();


            CreateMap<Equipment, EquipmentDto>();
            CreateMap<EquipmentDto, Equipment>();

            CreateMap<EquipmentForCreationDto, Equipment>();
            CreateMap<Equipment, EquipmentForCreationDto>();

            CreateMap<EquipmentForUpdateDto, Equipment>();
            CreateMap<Equipment, EquipmentForUpdateDto>();

            CreateMap<EquipmentForDeleteDto, Equipment>();
            CreateMap<Equipment, EquipmentForDeleteDto>();

            CreateMap<RatingDto, Rating>();
        }
    }

}
