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
         public int Disease_Id { get; set; }

        [ForeignKey("AppUser")]
         public int User_Id { get; set; }
         public byte[] Picture { get; set; }
         public string NameOfDisFromAIModel { get; set; }
         public FishDisease? Disease { get; set; }
         public Expert? Expert { get; set; }
         public  FarmOwner Owner { get; set; }
    }
}
