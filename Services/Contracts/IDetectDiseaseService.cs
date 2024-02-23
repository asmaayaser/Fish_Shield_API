using Microsoft.AspNetCore.Http;
using Services.DTO;

namespace Services.Contracts
{
    public interface IDetectDiseaseService
    {
        Task<DetectDto> CreateDetection(string OwnerId, IFormFile detectImage);
    }

}
