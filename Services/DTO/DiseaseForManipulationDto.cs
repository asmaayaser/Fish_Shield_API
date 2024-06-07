using CORE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public  record DiseaseForManipulationDto
    {
       
        [StringLength(50)]
        public string Name { get; init; }
        [StringLength(50)]
        public string Type { get; init; }

       
        [StringLength(500)]
        public string Description { get; init; }
      
        public ICollection<string> RecommandationActions { get; init; }
      
        public ICollection<string> CausativeAgents { get; init; }
       
        public ICollection<string> ClinicalSigns { get; init; }
      
        public ICollection<string> Diagnosis { get; init; }
       

        public ICollection<string> Treatment { get; init; }
      
        public ICollection<string> PreventionAndControlls { get; init; }
       
        public ICollection<string> ImpactOnAquacultures { get; init; }

    }
   

		public record DiseaseForCreationDto : DiseaseForManipulationDto { 
        public IFormFile PhotoPath { get; init; }
    }

    public record DiseaseDto:DiseaseForManipulationDto {
        public int ID { get; init; }
        public string PhotoPath { get; init; }
    }
    public record DiseaseForUpdatingDto : DiseaseDto;












}
