using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;

namespace Presentation
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IServiceManager service;

        public AdminController(IServiceManager service)
        {
            this.service = service;
        }

        #region Get

        #endregion
        #region post
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register([FromForm] AdminForRegistrationDto dto)
        {

            var Result = await service.adminService.Register(dto);
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
