using AutoMapper;
using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Commands
{
    public class DoctorRegistration : RegistrationBase, IRegistration
    {
        private readonly IMapper mapper;

        public DoctorRegistration(IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService, IHttpContextAccessor httpContextAccessor,IRepositoryManager manager) : base(userManager, roleManager, ioService, httpContextAccessor, manager)
        {
            this.mapper = mapper;
        }

        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegestration)
        {
            IdentityResult ResultForRegestrationProcess = IdentityResult.Failed();

            var DoctorDto = userForRegestration as DoctorForRegistrationDto;

            var resultOfCreatingTextualData = await Register(DoctorDto, user => mapper.Map<Doctor>(user));

            if (resultOfCreatingTextualData.Succeeded)
                ResultForRegestrationProcess = await HandleUPloadedImageProcess("Images/Personal", DoctorDto.PersonalPhoto, user.Id);
            else
                ResultForRegestrationProcess = resultOfCreatingTextualData;
            return ResultForRegestrationProcess;
        }
    }
}
