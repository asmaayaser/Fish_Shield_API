using CORE.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;
using Services.DTO;
using System.Text.Json;

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
        public async Task<IActionResult> GetAllFeeds([FromQuery]FeedbackParameters feedbackParameters)
        {
           var AllFeeds= await service.feedbackService.GetAllFeedbacks(feedbackParameters,track:false);
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(AllFeeds.metaInfo));
           return  Ok(AllFeeds.feedbacks);
        }
        #endregion
        #region Delete
        [HttpDelete]
        public async Task<IActionResult> DeleteFeed(HashSet<int> ids)
        {
            await service.feedbackService.DeleteFeedBacks(ids);
            return NoContent();
        }
        #endregion
    }
}
