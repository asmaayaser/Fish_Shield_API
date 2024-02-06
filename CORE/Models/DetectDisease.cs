using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    
    public class DetectDisease
    {
         public int Id { get; set; }
         public string  FishPhoto { get; set; }
         public  FarmOwner Owner { get; set; }
         public string NameOfDisFromAIModel { get; set; }
         public FishDisease? Disease { get; set; }
         public Expert? Expert { get; set; }
         public  FarmOwner Owner { get; set; }
    }
}
