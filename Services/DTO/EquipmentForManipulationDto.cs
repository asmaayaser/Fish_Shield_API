using CORE.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Services.DTO
{
    public record EquipmentForManipulationDto
    {
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int Count { get; set; }

        [StringLength(100)]
        public string OwnerId { get; set; }
    }

    public record EquipmentForCreationDto : EquipmentForManipulationDto
    {
        public IFormFile PhotoPath { get; init; }
    }

    public record EquipmentDto : EquipmentForManipulationDto
    {
        public int ID { get; set; }
        public string PhotoPath { get; init; }
    }
    public record EquipmentForUpdateDto : EquipmentForManipulationDto
    {
        public int ID { get; set; }
        public IFormFile PhotoPath { get; init; }

    }
    public record EquipmentForDeleteDto : EquipmentForManipulationDto
    {
        public int ID { get; set; }
    }
}
