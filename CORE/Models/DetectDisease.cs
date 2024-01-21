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
         public string NameOfDisFromAIModel { get; set; }
         public FishDisease? Disease { get; set; }
         public Doctor? Doctor { get; set; }
         public  FarmOwner Owner { get; set; }
    }
}
