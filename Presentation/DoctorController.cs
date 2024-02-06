using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;

namespace Presentation
{
    [Route("api/doctor")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IServiceManager service;

        public DoctorController(IServiceManager _service)
        {
            service = _service;

            
        }

        #region Get

        #endregion
        #region post
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task< IActionResult> Register([FromForm]DoctorForRegistrationDto dto)
        {

          var Result =   await  service.doctorService.Register(dto);
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
