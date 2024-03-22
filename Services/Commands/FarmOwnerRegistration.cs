using AutoMapper;
using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Services.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Commands
{
    public class FarmOwnerRegistration : RegistrationBase, IRegistration
    {
        private readonly IMapper mapper;
        private readonly IIOService ioService;

        public FarmOwnerRegistration(IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService) : base(userManager, roleManager, ioService, default)
        {
            this.mapper = mapper;
            this.ioService = ioService;
        }


        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegestration)
        {
            IdentityResult ResultForRegestrationProcess = IdentityResult.Failed();
            var resultOfCreatingTextualData = await Register(userForRegestration, user => mapper.Map<FarmOwner>(user));

            if (resultOfCreatingTextualData.Succeeded)
            {
                // create Folder
                var res = await CreateDirectory("Images/Detects", user.Id);
                if (!res)
                {
                    await DeleteUser(user);
                    resultOfCreatingTextualData = IdentityResult.Failed(new IdentityError() { Code = "CD Error", Description = "Some server internal error occurred while creating A Directory For this user Please try again Later " });
                }
            }
            ResultForRegestrationProcess = resultOfCreatingTextualData; // for Error equality
            return ResultForRegestrationProcess;


            async Task<bool> CreateDirectory(string FolderNameStructureInWWWROOT, string Dirname) => await ioService.CreateDirectory(FolderNameStructureInWWWROOT, Dirname);
        }

    }
}
