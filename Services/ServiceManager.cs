using AutoMapper;
using CORE.Contracts;
using CORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Repositories.Contracts;
using Services.Commands;
using Services.Contracts;
using Services.EmailService;
using Services.Queries.GetAll;
using Services.Queries.GetById;

namespace Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly Lazy<IDiseaseService> disease;
        private readonly Lazy<IDetectDiseaseService> detectDisease;
       
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
        private readonly IEmailSender emailSender;
        private readonly Lazy<IEquipmentService> equipment;

        public ServiceManager(IRepositoryManager manager,ILoggerManager logger,IMapper mapper,IConfiguration configuration, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IHttpContextAccessor httpContextAccessor,IIOService ioService,IWebHostEnvironment webHostEnvironment,IEmailSender emailSender)
        {
           
            disease=new Lazy<IDiseaseService>(()=>new DiseaseService(manager, logger,mapper,ioService,httpContextAccessor));
            detectDisease=new Lazy<IDetectDiseaseService>(() =>new DetectDiseaseService(manager,logger,mapper,ioService,httpContextAccessor,webHostEnvironment,configuration));
         
            authentication = new Lazy<IAuthentication>(() => new Authentication(manager,userManager,logger,mapper,configuration,emailSender,ioService));
            feedback = new Lazy<IFeedbackService>(() => new FeedbackService(manager, mapper));
            equipment = new Lazy<IEquipmentService>(() => new EquipmentService(manager, logger, mapper,ioService, httpContextAccessor));
            this.manager = manager;
            this.logger = logger;
            this.mapper = mapper;
            this.configuration = configuration;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
            this.ioService = ioService;
            this.webHostEnvironment = webHostEnvironment;
            this.emailSender = emailSender;
        }
        
        public IDiseaseService diseaseService => disease.Value;
        public IDetectDiseaseService detectDiseaseService =>detectDisease.Value;


        public IAuthentication AuthenticationService => authentication.Value;

        public IFeedbackService feedbackService => feedback.Value;
        public IEquipmentService equipmentService => equipment.Value;
        public void SetFarmOwnerStrategy()
        {
            AuthenticationService.registration = new FarmOwnerRegistration(mapper, userManager, roleManager, ioService,manager);
            AuthenticationService.getByIdDerivedTypes=new FarmOwnerGetById(manager, mapper);
        }

        public void SetAdminStrategy()
        {
            AuthenticationService.registration = new AdminRegistration(mapper, userManager, roleManager, ioService, httpContextAccessor,manager);
            AuthenticationService.getByIdDerivedTypes=new AdminGetById(manager, mapper);
        }
        public void SetDoctorStrategy() 
        {
            AuthenticationService.registration = new DoctorRegistration(mapper, userManager, roleManager, ioService, httpContextAccessor,manager);
            AuthenticationService.getAll = new GetAllDoctors(manager, mapper);
            AuthenticationService.getByIdDerivedTypes=new DoctorGetByID(manager, mapper);
        }
        
    }
}
