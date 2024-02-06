using AutoMapper;
using CORE.Contracts;
using CORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Contracts;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDiseaseService> disease;
        private readonly Lazy<IDetectDiseaseService> detectDisease;
        private readonly Lazy<IDoctorService> doctor;
        private readonly Lazy<IAdminService> admin;
        private readonly Lazy<IFarmOwnerService> farmOwner;

      
        public ServiceManager(IRepositoryManager manager,ILoggerManager logger,IMapper mapper,IConfiguration configuration, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IHttpContextAccessor httpContextAccessor,IFileService fileService)
        {
           
            disease=new Lazy<IDiseaseService>(()=>new DiseaseService(manager, logger,mapper));
            detectDisease=new Lazy<IDetectDiseaseService>(() =>new DetectDiseaseService(manager,logger,mapper));
            doctor = new Lazy<IDoctorService>(() => new DoctorService(mapper, logger, configuration,userManager,roleManager,httpContextAccessor,fileService));
            admin = new Lazy<IAdminService>(() => new AdminService(mapper, logger, configuration, userManager,roleManager,httpContextAccessor,fileService));
            farmOwner = new Lazy<IFarmOwnerService>(() => new FarmOwnerService(mapper, logger, configuration, userManager, roleManager, httpContextAccessor, fileService));

        }

        public IDiseaseService diseaseService => disease.Value;
        public IDetectDiseaseService detectDiseaseService =>detectDisease.Value;



        public IAdminService adminService => admin.Value;

        public IDoctorService doctorService => doctor.Value;

        public IFarmOwnerService farmOwnerService => farmOwner.Value;
    }
}
