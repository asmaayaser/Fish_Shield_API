using CORE.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services.Contracts;


namespace Presentation
{
    [Route("api/{OwnerId:guid}/Detects")]
    [ApiController]
    public class DetectDiseaseController:ControllerBase
    {
        private readonly IServiceManager serviceManager;

        public DetectDiseaseController(IServiceManager serviceManager)
        {
            this.serviceManager = serviceManager;
        }

        #region Get
        [HttpGet("generateReportData")]
        public async Task<IActionResult> GetReportData(Guid OwnerId ,[FromQuery]DetectionReportParameters detectionReportParameters)
        {
            var result =await serviceManager.detectDiseaseService.GenerateReport(OwnerId.ToString(),detectionReportParameters);
            return Ok(result);
        }
        #endregion
        #region post
        [HttpPost]
        
        public async Task<IActionResult> CreateDetectProcess(Guid OwnerId,IFormFile ImageForDetection)
        {
            var Result = await serviceManager.detectDiseaseService.CreateDetection(OwnerId.ToString(), ImageForDetection);
            return Ok(Result);
        }
        #endregion
        #region Put

        #endregion
        #region delete

        #endregion
    }
}
