using CORE.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
   [Route("api/Accounts")]
   [ApiController]
   public class AccountController:ControllerBase
   {
        private readonly IServiceManager service;
        private readonly SignInManager<AppUser> signInManager;

        public AccountController(IServiceManager service,SignInManager<AppUser> signInManager)
        {
            this.service = service;
            this.signInManager = signInManager;
        }

        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Login([FromForm] UserForLoginDto userForLoginDto)
        {
            if (!await service.AuthenticationService.ValidateUser(userForLoginDto))
                return Unauthorized("User password or User name is Wrong");

            var token = await service.AuthenticationService.CreateToken(PopulateExpiration: true);

            return Ok(token);
        }

        //[HttpGet("ExternalLogin")]
        //public IActionResult ExternalLogin(string provider)
        //{
        //    var properties = new AuthenticationProperties
        //    {
        //        RedirectUri = "https://localhost:7289" + Url.Action(nameof(ExternalLoginCallback)),
        //        Items ={
        //                  { "scheme", provider },
        //               }
        //    };

        //    return Challenge(properties, provider);
        //}

        //[HttpGet("ExternalLoginCallback")]
        //public async Task<IActionResult> ExternalLoginCallback()
        //{
        //    var result = await HttpContext.AuthenticateAsync("Cookies");
        //    var externalUserId = result.Principal.FindFirstValue(ClaimTypes.NameIdentifier);

        //    // Use externalUserId to identify the user or create a new account

        //    // Redirect to your application's home page or dashboard
        //    return Redirect("/home");
        //}
    }
}
