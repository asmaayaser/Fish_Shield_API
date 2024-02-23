using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Repositories.Context;
using Services.Contracts;
using Services.DTO;

namespace Presentation
{
    [Route("api/Accounts/doctor")]
    [ApiController]
    public class DoctorController : AccountController
    {
        private readonly IServiceManager service;

        public DoctorController(IServiceManager service, SignInManager<AppUser> signInManager) : base(service, signInManager)
        {
           this.service = service;
            service.SetDoctorStrategy();
            
        }

        #region Get
        [HttpGet]
        public async Task<IActionResult> GetAllDoctors()
        {
            var Result = await service.AuthenticationService.GetAllDreivedTypesAsync(track:false);
            return Ok(Result);
        }
        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var appUser = await service.AuthenticationService.GetByIdDerivedTypeAsync(id,track:false);

            return Ok(appUser);
        }
        #endregion
        #region post
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task< IActionResult> Register([FromForm]DoctorForRegistrationDto dto)
        {

          var Result =   await service.AuthenticationService.Registration(dto);
            if (!Result.Succeeded)
            {
                foreach (var Error in Result.Errors)
                    ModelState.TryAddModelError(Error.Code, Error.Description);

                return BadRequest(ModelState);
            }
            return StatusCode(StatusCodes.Status201Created);
        }
       
        #endregion
        #region Put

        #endregion
        #region Delete

        #endregion
    }
}
