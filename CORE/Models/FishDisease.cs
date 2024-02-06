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

        public byte[] Picture { get; set; }

        [MaxLength(1500)]
        public string Description { get; set; }

        [MaxLength(1500)]
        public string Causative_Agents { get; set; }

        [MaxLength(1500)]
        public string Transmission { get; set; }

        [MaxLength(1500)]
        public string Diagnosis { get; set; }

        [MaxLength(1500)]
        public string Treatment { get; set; }

        [MaxLength(1500)]
        public string Prevention_And_Control { get; set; }

        [MaxLength(1500)]
        public string Impact_On_Aquaculture { get; set; }

        [MaxLength(1500)]
        public string Clinical_Signs { get; set; }

    }
}
