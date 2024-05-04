using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    
    public class DetectDisease
    {
         public int Id { get; set; }
         public string  FishPhoto { get; set; }
        
         public string UserId { get; set; }
         public PaymentUserAccount User { get; set; }

         public string NameOfDisFromAIModel { get; set; }
         public float Score { get; set; }
         public int? DiseaseId { get; set; }
         public FishDisease? Disease { get; set; }

         public DateTime DateTime { get; set; } = DateTime.Now;

    }
}
