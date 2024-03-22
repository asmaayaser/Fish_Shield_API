using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{
    [Route("api/Accounts/farmOwner")]
    [ApiController]
    public class FarmOwnerController:ControllerBase
    {
        private readonly IServiceManager service;

        public FarmOwnerController(IServiceManager service)
        {
            this.service = service;
            service.SetFarmOwnerStrategy();
        }
        #region Get
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            var result= await service.AuthenticationService.GetByIdDerivedTypeAsync(id, track: false);
            return Ok(result);
        }

        #endregion
        #region post
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Register([FromForm] FarmOwnerForRegistrationDto farmOwner)
        {
          
          
           var Result = await service.AuthenticationService.Registration(farmOwner);
         // var Result= await service.farmOwnerService.Register(farmOwner);
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
