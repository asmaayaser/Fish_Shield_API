using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.DTO;

namespace Presentation
{
    [Route("api/Feedbacks")]
    [ApiController]
    public class FeedBacksController:ControllerBase
    {
        private readonly IServiceManager service;

        public FeedBacksController(IServiceManager service)
        {
            this.service = service;
        }

        #region post
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilter.ValidationFilterAttribute))]
        public async Task<IActionResult> Create(FeedbackForCreationDto feedbackForCreationDto)
        {
            await service.feedbackService.InsertFeedback(feedbackForCreationDto);
            return StatusCode(StatusCodes.Status200OK);
        }

        #endregion
        #region get

       
        [HttpGet]
       // [Authorize(Roles ="Admin")]
        public async Task<IActionResult> GetAllFeeds()
        {
           var AllFeeds= await service.feedbackService.GetAllFeedbacks(track:false);
           return  Ok(AllFeeds);
        }
        #endregion
    }
}
