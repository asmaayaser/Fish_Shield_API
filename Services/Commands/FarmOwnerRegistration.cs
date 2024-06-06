using AutoMapper;
using CORE.Models;
using Microsoft.AspNetCore.Identity;
using Repositories.Contracts;
using Services.Contracts;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Commands
{
    public class FarmOwnerRegistration : RegistrationBase, IRegistration
    {
        private readonly IMapper mapper;
        private readonly IIOService ioService;

        public FarmOwnerRegistration(IMapper mapper, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService,IRepositoryManager manager) : base(userManager, roleManager, ioService, default,manager)
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


   

    public class FarmOwnerUpdateData :IUpdateUserData
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public FarmOwnerUpdateData(IRepositoryManager manager, IMapper mapper,UserManager<AppUser> userManager)
            
        {
            this.manager = manager;
            this.mapper = mapper;
            this.userManager = userManager;
        }



        public async Task<IdentityResult> UpdateUserDataAsync(UserForUpdateDto userForupdateDto)
        {
            var Result = IdentityResult.Failed(new IdentityError() {Code="", Description="no farm owner Exist with that id"});
            
            var newfarmData = userForupdateDto as FarmOwnerForUpdateDto;
            var oldFarmdata = await manager.farmOwner.GetFarmOwnerById(Guid.Parse(userForupdateDto.Id),track:true);
            if (oldFarmdata is not null)
            {
               mapper.Map(newfarmData, oldFarmdata);
               Result = await userManager.UpdateAsync(oldFarmdata);
            }
            return Result;

        }
    }

    public class DoctorUpdateData : IUpdateUserData
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;

        public DoctorUpdateData(IRepositoryManager manager, IMapper mapper, UserManager<AppUser> userManager)
        {
            this.manager = manager;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<IdentityResult> UpdateUserDataAsync(UserForUpdateDto userForUpdateDto)
        {
            var Result = IdentityResult.Failed(new IdentityError() { Code = "", Description = "no doctor  Exist with that id" });

            var newdoctorData = userForUpdateDto as DoctorForUpdateDto;
            var olddoctordata = await manager.Doctors.GetDoctorById(Guid.Parse(userForUpdateDto.Id), track: true);
            if (olddoctordata is not null)
            {
                mapper.Map(newdoctorData, olddoctordata);
                Result = await userManager.UpdateAsync(olddoctordata);
            }
            return Result;
        }
    }
}
