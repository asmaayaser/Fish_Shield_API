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
    public class FarmOwnerService :AppUserCommonService, IFarmOwnerService
    {
      
        private readonly ILoggerManager logger;
        private readonly IConfiguration configuration;
      
        

        public FarmOwnerService(IMapper mapper, ILoggerManager logger, IConfiguration configuration, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IHttpContextAccessor httpContextAccessor,IFileService fileService)
            :base(mapper, userManager, roleManager, httpContextAccessor, fileService)
        {
           
            this.logger = logger;
            this.configuration = configuration;
           
          
        }



        public  async Task<IdentityResult> Register(FarmOwnerForRegistrationDto farmOwnerForRegistrationDto)
        {
           var Results= await base.Register(farmOwnerForRegistrationDto,user=> mapper.Map<FarmOwner>(user));


            if(Results.Succeeded)
            {
                // create Folder
               var res=  await base.CreateDirectory("Images/Detects", user.Id);
                if (res == false)
                {
                    Results = IdentityResult.Failed();
                    await base.DeleteUser(user);
                }
            }
            return Results;
        }






    }
}
