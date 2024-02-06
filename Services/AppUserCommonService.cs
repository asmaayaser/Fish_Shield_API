using AutoMapper;
using Azure.Core;
using CORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Services.Contracts;
using Services.DTO;

namespace Services
{
    public abstract class AppUserCommonService : IAppUserCommonService
    {
        protected readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IFileService fileService;
        protected AppUser? user;
       
        
        public AppUserCommonService(IMapper mapper, UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IHttpContextAccessor httpContextAccessor,IFileService fileService)
        {
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.httpContextAccessor = httpContextAccessor;
            this.fileService = fileService;
        }




        public  async Task<IdentityResult> Register(UserForRegestrationDto userForRegistrationDto, Func<UserForRegestrationDto, AppUser> map)
        {
            user = map.Invoke(userForRegistrationDto);

            var CreateResult = await userManager.CreateAsync(user, userForRegistrationDto.Password);
            
            if (CreateResult.Succeeded)
            {
                if (await roleManager.RoleExistsAsync(userForRegistrationDto.Role))
                    await userManager.AddToRoleAsync(user, userForRegistrationDto.Role);
                else
                    throw new RoleNotFoundException(userForRegistrationDto.Role);
            }
           
            return CreateResult;
        }

       

        protected async Task<IdentityResult> updateUesrImage(AppUser user) => await userManager.UpdateAsync(user);

        protected async Task DeleteUser(AppUser user)=>await userManager.DeleteAsync(user);
        
        protected async Task<IdentityResult> HandleUPloadedImageProcess(string FolderNamingStructureInsideWWWRoot,IFormFile image,string NewNameForImage)
        {


            var imageRelativePath = await fileService.uploadImage(FolderNamingStructureInsideWWWRoot, image, NewNameForImage);
            var HostUrl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host;
            user.PersonalPhoto = $"{HostUrl}/{imageRelativePath}";
            IdentityResult updated = await updateUesrImage(user);

            if (!updated.Succeeded)
            {
                await DeleteUser(user);
                return IdentityResult.Failed();
            }
            return IdentityResult.Success;
        }
       
        
        protected async Task<bool> CreateDirectory(string FolderNameStructureInWWWROOT, string Dirname)=> await fileService.CreateDirectory(FolderNameStructureInWWWROOT, Dirname);
        

    }





}
