using CORE.Models;
using CORE.Shared;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Presentation
{
   [Route("api/Accounts")]
   [ApiController]
   public class AccountController:ControllerBase
   {
        private readonly IServiceManager service;
     

        public AccountController(IServiceManager service)
        {
            this.service = service;
          
        }

        #region Post
        [HttpPost("login")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Login([FromForm] UserForLoginDto userForLoginDto)
        {
            if (!await service.AuthenticationService.ValidateUser(userForLoginDto))
                return Unauthorized("User password or User name is Wrong");


            var token = await service.AuthenticationService.CreateToken(PopulateExpiration: true);

            //  await service.AuthenticationService.TestEmailSending();
            return Ok(token);
        }


        [HttpPost("forgot")]
        public async Task<IActionResult> ForgotPassword(ForgetPasswordDto model)
        {
            var result = await service.AuthenticationService.ForgotPasswordAsync(model);

            if (result)
            {
                return Ok("Password reset email sent successfully.");
            }
            else
            {
                return BadRequest("Failed to send password reset email.");
            }
        }

        [HttpPost("reset-password")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> ResetPassword(ResetPasswordDto model)
        {
            var result = await service.AuthenticationService.ResetPasswordAsync(model);

            if (!result.Succeeded)
            {
                foreach (var Error in result.Errors)
                {
                    ModelState.TryAddModelError(Error.Code, errorMessage: Error.Description);
                }
                return BadRequest(ModelState);
            }

            return Ok("Password reset successful.");
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery]AppUserParameters appUserParameters)
        {
            var result=await service.AuthenticationService.GetAllUsers(appUserParameters,track: false);
            Response.Headers.Add("X-Pagination",JsonSerializer.Serialize(result.meta));
            return Ok(result.allusers);
        }
        [HttpPost("IsCodeEnterTrue")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> IsEnterdCodeIsValid([FromBody] verifyResetPasswordDto verifyResetPasswordDto)
        {
           return Ok(await service.AuthenticationService.IsCodeEnterTrue(verifyResetPasswordDto));
        }

        [HttpGet("IsSubscripted")]
        public async Task<IActionResult> IsSubscripted(Guid id)
        {
            return Ok(await service.AuthenticationService.IsThisAccountSubscriptedMember(id));
        }

        #endregion

        #region Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteAllUsersWithIDs(IEnumerable<Guid> ids)
        {
            var idsConversion=ids.Select(i=>i.ToString()).ToList();
            await service.AuthenticationService.DeleteUsers(idsConversion);
            return  NoContent();
        }

        #endregion

        #region Put
        [HttpPut("EnableAndDisableAccount")]
        public async Task<IActionResult> DisableOrEnableAccounts(List<Guid> ids)
        {
            var idsConversion=ids.Select(ids=>ids.ToString()).ToList();
            await service.AuthenticationService.DisableOrEnableAccounts(idsConversion);
            return NoContent();
        }

        [HttpPut("UpdateUserPassword")]
        [ServiceFilter(typeof (ValidationFilterAttribute))]
        public async Task<IActionResult> UpdateUserPassword(UpdateUserPasswordDto updareUserPasswordDto)
        {
             var Result= await  service.AuthenticationService.ChangeUserPassword(updareUserPasswordDto);
            if (!Result.Succeeded)
            {
                foreach (var Error in Result.Errors)
                    ModelState.TryAddModelError(Error.Code, Error.Description);

                return BadRequest(ModelState);
            }
            return StatusCode(StatusCodes.Status202Accepted);
        }
        [HttpPut("updatePersonalPhoto/{id:guid}")]
        public async Task<IActionResult> UpdatePersonalPhoto(IFormFile photo, Guid id)
        {
            await service.AuthenticationService.updateUserImage(photo, id);
            return StatusCode(StatusCodes.Status202Accepted);
        }
        [HttpPut("subscribe")]
        public async Task<IActionResult> Subscription(Guid id)
        {
            await service.AuthenticationService.MakeSubscription(id);

            return Ok("this Account now marked as Subscripted user account");
        }
		#endregion


		#region PAyment
		[HttpPost("create-checkout-session")]
		public async Task<IActionResult> CreateCheckoutSession(Guid ownerId)
		{

			var sessionUrl =await service.PaymentService.CreateCheckoutSession(ownerId.ToString(),
			   "https://localhost:7289/api/Accounts/success?sessionId={CHECKOUT_SESSION_ID}",
			   "https://localhost:7289/api/Accounts/cancel?sessionId={CHECKOUT_SESSION_ID}"
			);

			return Ok (sessionUrl );
		}

		[HttpGet("success")]
		public async Task<IActionResult> Success(string sessionId)
		{
		    await service.PaymentService.SuccessPayment(sessionId);
			// Redirect to a success page or return success response
			return Ok("Payment successful.");
		}

		[HttpGet("cancel")]
		public async Task<IActionResult> Cancel(string sessionId)
		{
            await service.PaymentService.CancelledPayment(sessionId);
			// Redirect to a cancel page or return cancel response
			return Ok("Payment cancelled.");
		}
		#endregion
	}

    


}

