using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;

namespace Presentation
{
    [Route("api/Tokens")]
    [ApiController]
    public class TokensController:ControllerBase
    {
        private readonly IServiceManager service;

        public TokensController(IServiceManager service)
        {
            this.service = service;
        }


        [HttpPost("Refresh")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Refresh(TokenDto tokendto)
        {
           var RefreshedToken=  await service.AuthenticationService.RefreshToken(tokendto);

            return Ok(RefreshedToken);
        }
    }
}
