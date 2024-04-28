using CORE.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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
        [HttpGet("IsSubscripted")]
        public async Task<IActionResult> IsSubscripted(Guid id)
        {
          return Ok(await service.AuthenticationService.IsThisFarmOwnerAccountSubscriptedMember(id));
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


        [HttpPost("setDoctorRating")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> PostRateForDoctor(RatingDto ratingDto)
        {
            await service.AuthenticationService.SetRatingForDoctor(ratingDto);
            return Ok("rating is set to that doctor thanks..");
        }
        #endregion

        #region Put
        [HttpPut("subscribe")]
        public async Task<IActionResult> Subscription(Guid id)
        {
            await service.AuthenticationService.MakeSubscriptionForFarmOwner(id);

            return Ok("this farm owner now marked as Subscripted user account");
        }

        [HttpPut]
        [ServiceFilter(type: typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateData(FarmOwnerForUpdateDto farmOwnerForUpdateDto)
        {
           var Result=  await service.AuthenticationService.UpdateUserData(farmOwnerForUpdateDto);
            if (!Result.Succeeded)
            {
                foreach (var Error in Result.Errors)
                    ModelState.TryAddModelError(Error.Code, Error.Description);

                return BadRequest(ModelState);
            }
            return StatusCode(StatusCodes.Status202Accepted);
        }
            
        #endregion
        #region Delete

        #endregion
    }
}
