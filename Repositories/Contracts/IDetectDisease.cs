using CORE.Models;
using CORE.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Contracts
{
    public interface IDetectDiseaseRepository
    {
        DetectDisease Create(string farmOwnerId, DetectDisease detect);
        Task<ReportDto> GetReportAnalysis(string farmOwnerId, DetectionReportParameters detectionReportParameters);
    }

    public record ReportDto
    {
        public int NumberOfDetections { get; init; }
        public DateTime LastDetection { get; init; }
        public string MostCommonDisease {  get; init; }
        public List<string> OtherDiseaseApperred { get; init; }

        public List<DetectDisease> DetectionHistory { get; init; }
    }
}