using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public record UserForUpdateDto
    {
        public string Id { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime BirthDate { get; init; }
        [Required(ErrorMessage = "Email is Required")]
        public string Email { get; init; }
        [Required(ErrorMessage = "Username is Required")]
        public string UserName { get; init; }
        [StringLength(11)]
        public string PhoneNumber { get; init; }

    }

    public record FarmOwnerForUpdateDto:UserForUpdateDto
    {
        [Required(ErrorMessage = "Farm address Must Provided")]
        public string FarmAddress { get; init; }
        public string? Address { get; init; }
    }
    public record DoctorForUpdateDto : UserForUpdateDto
    {
        public string? MoreInfo { get; init; }
        public string Address { get; init; }
    }
}

