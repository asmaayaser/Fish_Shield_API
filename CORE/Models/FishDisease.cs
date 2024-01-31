using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CORE.Models
{
    public class FishDisease
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        
        [StringLength(100)]
        public string PhotoPath { get; set; }
        [StringLength(500)]
        public string Description { get; set; }
        public string RecomAction { get; set; }

        public ICollection<string> CausativeAgents { get; set; }
        public ICollection<string> ClinicalSigns { get; set; }
        public ICollection<string> Diagnosis { get; set; }
        public ICollection<string> Treatment { get; set; }
        public ICollection<string> PreventionAndControll { get; set; }
        public ICollection<string> ImpactOnAquaculture { get; set; }








    }
}
