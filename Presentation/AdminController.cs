using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Serialization;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;

namespace Presentation
{
    [Route("api/Accounts/Admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager service;

        public AdminController(IServiceManager service) 
        {
            this.service = service;
            service.SetAdminStrategy();
        }

        #region Get
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
          var adminData= await  service.AuthenticationService.GetByIdDerivedTypeAsync(id, track: false);
          return Ok(adminData);
        }
        #endregion
        #region post
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register([FromForm] AdminForRegistrationDto dto)
        {

            var Result = await service.AuthenticationService.Registration(dto);
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
