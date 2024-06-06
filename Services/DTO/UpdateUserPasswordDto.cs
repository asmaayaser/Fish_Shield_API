using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public record UpdateUserPasswordDto
    {
        public string Id { get; init; }
        [Required(ErrorMessage = "old Password is Required"), DataType(DataType.Password)]
        public string oldPassword { get; init; }
        [Required(ErrorMessage = "new Password is Required"), DataType(DataType.Password)]
        public string newPassword { get; init; }
        [Compare(nameof(newPassword), ErrorMessage = "Password and Confirm Password not Identical"), DataType(DataType.Password)]
        public string ConfirmPass { get; init; }
    }
}

