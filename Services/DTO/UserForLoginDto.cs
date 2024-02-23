using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public record UserForLoginDto
    {
        [Required]
        public string Username { get; init; }
        [Required,DataType(DataType.Password)]
        public string Password { get; init; }
    }
}

