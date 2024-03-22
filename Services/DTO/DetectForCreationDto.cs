using CORE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
   
    public record DetectDto
    {
        public string FishPhoto { get; set; }
        public string OwnerId { get; set; }
        public string NameOfDisFromAIModel { get; set; }
        public float Score { get; set; }
        public int? DiseaseId { get; set; }
        public DiseaseDto? Disease { get; set; }
        public DateTime DateTime { get; set; }
    }


}
