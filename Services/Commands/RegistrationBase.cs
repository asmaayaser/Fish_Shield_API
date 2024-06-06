using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;
using System.Text.Encodings.Web;
using System.Text;
using System;

namespace Services.Commands
{
    public abstract class RegistrationBase
    {
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IIOService ioService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IRepositoryManager manager;
        protected AppUser user;



        public RegistrationBase(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IIOService ioService, IHttpContextAccessor httpContextAccessor,IRepositoryManager manager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.ioService = ioService;
            this.httpContextAccessor = httpContextAccessor;
            this.manager = manager;
            
        }



        public async Task<IdentityResult> Register(UserForRegestrationDto userForRegistrationDto,Func<UserForRegestrationDto, AppUser> map)
        {
            #region MyRegion
            user = map.Invoke(userForRegistrationDto);


            var CreateResult = await userManager.CreateAsync(user, userForRegistrationDto.Password);
            var ActualTypeforUser = user.GetType();
            if (CreateResult.Succeeded)
            {
                if (ActualTypeforUser == typeof(Admin) && await roleManager.RoleExistsAsync("Admin"))
                    await userManager.AddToRoleAsync(user, "Admin");
                else if (ActualTypeforUser == typeof(Doctor) && await roleManager.RoleExistsAsync("Doctor"))
                    await userManager.AddToRoleAsync(user, "Doctor");
                else if (ActualTypeforUser == typeof(FarmOwner) && await roleManager.RoleExistsAsync("FarmOwner"))
                    await userManager.AddToRoleAsync(user, "FarmOwner");
                else
                {
                    await DeleteUser(user);
                    throw new RoleNotFoundException();
                }
            }
            return CreateResult; 
            #endregion
        }
        protected async Task DeleteUser(AppUser user) => await userManager.DeleteAsync(user);

        protected async Task<IdentityResult> HandleUPloadedImageProcess(string FolderNamingStructureInsideWWWRoot, IFormFile image, string NewNameForImage)
        {
            var imageRelativePath = await ioService.uploadImage(FolderNamingStructureInsideWWWRoot, image, NewNameForImage);
            var HostUrl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host;
            user.PersonalPhoto = $"{HostUrl}/{imageRelativePath}";
            IdentityResult updated = await userManager.UpdateAsync(user);
            if (!updated.Succeeded)
            {
                await DeleteUser(user);
                return IdentityResult.Failed();
            }
            return IdentityResult.Success;
        }
        protected async Task<IdentityResult> HandleUPloadedCertificateImageProcess(string FolderNamingStructureInsideWWWRoot, IFormFile image, string NewNameForImage)
        {
            var imageRelativePath = await ioService.uploadImage(FolderNamingStructureInsideWWWRoot, image, NewNameForImage);
            var HostUrl = httpContextAccessor.HttpContext.Request.Scheme + "://" + httpContextAccessor.HttpContext.Request.Host;
            var doc = user as Doctor;
            doc.Certificate = $"{HostUrl}/{imageRelativePath}";
            IdentityResult updated = await userManager.UpdateAsync(doc);
            if (!updated.Succeeded)
            {
                await DeleteUser(user);
                return IdentityResult.Failed();
            }
            return IdentityResult.Success;
        }


    }
}
