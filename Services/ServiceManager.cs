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
        #region obseleted
        //private readonly Lazy<IDoctorService> doctor;
        //private readonly Lazy<IAdminService> admin;
        //private readonly Lazy<IFarmOwnerService> farmOwner; 
        #endregion
        private readonly Lazy<IAuthentication> authentication;
        private readonly Lazy<IFeedbackService> feedback;
        private readonly IRepositoryManager manager;

        // set 
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IConfiguration configuration;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IIOService ioService;
        private readonly IWebHostEnvironment webHostEnvironment;



        public ServiceManager(IRepositoryManager manager,ILoggerManager logger,IMapper mapper,IConfiguration configuration, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IHttpContextAccessor httpContextAccessor,IIOService ioService,IWebHostEnvironment webHostEnvironment)
        {
           
            disease=new Lazy<IDiseaseService>(()=>new DiseaseService(manager, logger,mapper,ioService,httpContextAccessor));
            detectDisease=new Lazy<IDetectDiseaseService>(() =>new DetectDiseaseService(manager,logger,mapper,ioService,httpContextAccessor,webHostEnvironment));
         
            authentication = new Lazy<IAuthentication>(() => new Authentication(manager,userManager,logger,mapper,configuration));
            feedback = new Lazy<IFeedbackService>(() => new FeedbackService(manager, mapper));
            this.manager = manager;
            this.logger = logger;
            this.mapper = mapper;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
            this.ioService = ioService;
            this.webHostEnvironment = webHostEnvironment;
        }
        
        public IDiseaseService diseaseService => disease.Value;
        public IDetectDiseaseService detectDiseaseService =>detectDisease.Value;



        #region obseleted
        //public IAdminService adminService => admin.Value;

        //public IDoctorService doctorService => doctor.Value;

        //public IFarmOwnerService farmOwnerService => farmOwner.Value; 
        #endregion

        public IAuthentication AuthenticationService => authentication.Value;

        public IFeedbackService feedbackService => feedback.Value;

        public void SetFarmOwnerStrategy() => AuthenticationService.registration = new FarmOwnerRegistration(mapper, userManager, roleManager, ioService);
        public void SetAdminStrategy()=>AuthenticationService.registration=new AdminRegistration(mapper, userManager, roleManager, ioService,httpContextAccessor);
        public void SetDoctorStrategy() 
        {
            AuthenticationService.registration = new DoctorRegistration(mapper, userManager, roleManager, ioService, httpContextAccessor);
            AuthenticationService.getAll = new GetAllDoctors(manager, mapper);
            AuthenticationService.getByIdDerivedTypes=new DoctorGetByID(manager, mapper);
        }
        
    }
}
