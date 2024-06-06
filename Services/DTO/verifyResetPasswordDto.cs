using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
	public record verifyResetPasswordDto
    {
        [Required, EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Code { get; init; }
    }

    public record ResetPasswordDto : verifyResetPasswordDto
    {
        [Required, DataType(DataType.Password)]
        public string Pass { get; init; }

        [Required, Compare("Pass")]
        public string ConfirmPass { get; init; }
    }
}

