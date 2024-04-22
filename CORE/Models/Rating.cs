using System.ComponentModel.DataAnnotations.Schema;

namespace CORE.Models
{
    public class Rating
    {
        public int id { get; set; }

        public decimal Rate { get; set; }
        [ForeignKey("owner")]
        public string ownerId { get; set; }

        [ForeignKey("Doctor")]
        public string DoctorId { get; set; }

        public FarmOwner owner { get; set; }
        public Doctor Doctor { get; set; }
    }
}
