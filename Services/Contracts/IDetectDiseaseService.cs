using CORE.Shared;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Services.DTO;

namespace Services.Contracts
{
    public interface IDetectDiseaseService
    {
        Task<DetectDto> CreateDetection(string OwnerId, IFormFile detectImage);
        Task<ReportDto> GenerateReport(string OwnerId, DetectionReportParameters detectionReportParameters);
    }

}
