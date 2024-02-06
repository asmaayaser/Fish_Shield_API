using AutoMapper;
using CORE.Contracts;
using CORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Services.Contracts;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class DoctorService :AppUserCommonService,IDoctorService
    {
     
        private readonly ILoggerManager logger;
        private readonly IConfiguration configuration;
       

        public DoctorService(IMapper mapper,ILoggerManager logger,IConfiguration configuration,UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IHttpContextAccessor httpContextAccessor,IFileService fileService)
            :base(mapper,userManager, roleManager,httpContextAccessor,fileService)
        {
            this.logger = logger;
            this.configuration = configuration;
           
        }

       

        public async Task<IdentityResult> Register(DoctorForRegistrationDto dto)
        {
            IdentityResult ResultForRegestrationProcess=IdentityResult.Failed();

            var resultOfCreatingTextualData = await base.Register(dto,user=>mapper.Map<Doctor>(user));

            if (resultOfCreatingTextualData.Succeeded)
                ResultForRegestrationProcess = await base.HandleUPloadedImageProcess("Images/Personal", dto.PersonalPhoto, user.Id);
           
            return ResultForRegestrationProcess;

        }

       
    }
}
