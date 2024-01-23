using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public /*abstract*/ record DiseaseForManipulationDto
    {
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string Type { get; set; }

        public string RecomActions { get; set; }
    }

    public record DiseaseForCreationDto:DiseaseForManipulationDto { }
    public record DiseaseForUpdatingDto : DiseaseForManipulationDto { }
}
