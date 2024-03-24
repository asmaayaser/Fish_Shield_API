using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Equipment
    {
        public int ID { get; set; }
        [StringLength(50)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        public int Count { get; set; }

        [StringLength(100)]
        public string? PhotoPath { get; set; }

        [ForeignKey("Owner")]
        public string OwnerId { get; set; }
        public FarmOwner? Owner { get; set; }

    }
}