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
        private readonly IIOService ioService;

        public DoctorRegistration(IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService, IHttpContextAccessor httpContextAccessor,IRepositoryManager manager) : base(userManager, roleManager, ioService, httpContextAccessor, manager)
        {
            this.mapper = mapper;
            this.ioService = ioService;
        }

        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegestration)
        {
            IdentityResult ResultForRegestrationProcess = IdentityResult.Failed();

            var DoctorDto = userForRegestration as DoctorForRegistrationDto;

            var resultOfCreatingTextualData = await Register(DoctorDto, user => mapper.Map<Doctor>(user));

            if (resultOfCreatingTextualData.Succeeded)
            {
                // create Folder
                var res = await CreateDirectory("Images/Detects", user.Id);
                if (!res)
                {
                    await DeleteUser(user);
                    resultOfCreatingTextualData = IdentityResult.Failed(new IdentityError() { Code = "CD Error", Description = "Some server internal error occurred while creating A Directory For this user Please try again Later " });
                }

                ResultForRegestrationProcess = await HandleUPloadedImageProcess("Images/Personal", DoctorDto.PersonalPhoto, user.Id);
                if(ResultForRegestrationProcess.Succeeded)
                {
                    ResultForRegestrationProcess = await HandleUPloadedCertificateImageProcess("Images/Certificates", DoctorDto.Certificate, user.Id);
                }

            }
            else
                ResultForRegestrationProcess = resultOfCreatingTextualData;
            return ResultForRegestrationProcess;



            async Task<bool> CreateDirectory(string FolderNameStructureInWWWROOT, string Dirname) => await ioService.CreateDirectory(FolderNameStructureInWWWROOT, Dirname);
        }
    }
}
