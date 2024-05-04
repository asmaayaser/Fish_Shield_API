using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Cryptography;
using System.Text;
using CORE.Models;
using CORE.Shared;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class DetectDiseaseRepository : Repositorybase<DetectDisease>, IDetectDiseaseRepository
    {
        public DetectDiseaseRepository(RepositoryContext context) : base(context)
        {
        }

        public DetectDisease Create(string farmOwnerId, DetectDisease detect)
        {
            detect.UserId = farmOwnerId;
            base.Add(detect);
            return detect;
        }

        public async Task<ReportDto> GetReportAnalysis(string farmOwnerId, DetectionReportParameters detectionReportParameters)
        {
          
             var Detections=await base.FindByCondition(
                 d => (d.UserId.Equals(farmOwnerId)&&
                 (d.DateTime>=detectionReportParameters.StartDate && d.DateTime<=detectionReportParameters.EndDate)), TrackChanges: false).Include(d=>d.Disease).ToListAsync();
           
            var history = await base.FindByCondition(
                 d => (d.UserId.Equals(farmOwnerId) &&
                 (d.DateTime >= detectionReportParameters.StartDate && d.DateTime <= detectionReportParameters.EndDate)), TrackChanges: false).OrderByDescending(d=>d.DateTime).ToListAsync();
            
            var numberOfDetections=Detections.Count();
            var LastDetection=history.Select(d=>d.DateTime).FirstOrDefault();

            var mostCommonDisease = Detections
            .GroupBy(d => d.Disease)
            .OrderByDescending(g => g.Count())
            .Select(g => g.Key)
            .FirstOrDefault();

            // Other Diseases Appeared
            var otherDiseasesAppeared = Detections
                .Where(d => d.UserId == farmOwnerId && d.Disease.Name != mostCommonDisease.Name)
                .Select(d =>d.Disease.Name)
                .Distinct()
                .ToList();

            return new ReportDto()
            {
                NumberOfDetections = numberOfDetections,
                DetectionHistory = history,
                LastDetection = LastDetection,
                MostCommonDisease = mostCommonDisease?.Name,
                OtherDiseaseApperred = otherDiseasesAppeared
            };
        }
    }
}