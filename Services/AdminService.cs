using AutoMapper;
using CORE.Contracts;
using CORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;
using Services.DTO;

namespace Services
{
    public class AdminService :AppUserCommonService ,IAdminService
    {
       
        private readonly ILoggerManager logger;
        private readonly IConfiguration configuration;
       

        public AdminService(IMapper mapper, ILoggerManager logger, IConfiguration configuration, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IHttpContextAccessor httpContextAccessor,IFileService fileService)
            :base(mapper,userManager, roleManager,httpContextAccessor,fileService) 
        {
           
            this.logger = logger;
            this.configuration = configuration;
           
        }

        public async Task<IdentityResult> Register(AdminForRegistrationDto dto)
        {
            IdentityResult ResultForRegestrationProcess = IdentityResult.Failed();

            var resultOfCreatingTextualData = await base.Register(dto, user => mapper.Map<Admin>(user));

            if (resultOfCreatingTextualData.Succeeded)
                ResultForRegestrationProcess = await base.HandleUPloadedImageProcess("Images/Personal", dto.PersonalPhoto, user.Id);

            return ResultForRegestrationProcess;
        }
    }
}
