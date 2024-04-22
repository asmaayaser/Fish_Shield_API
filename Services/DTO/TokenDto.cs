using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public record TokenDto(string AccessToken, string RefreshToken);

    public record ForgetPasswordDto([Required, EmailAddress] string Email);
    public record ResetPasswordDto:verifyResetPasswordDto
    {
        [Required, DataType(DataType.Password)]
        public string Pass { get; init; }

        [Required, Compare("Pass")]
        public string ConfirmPass { get; init; }
    }
    public record verifyResetPasswordDto
    {
        [Required, EmailAddress]
        public string Email { get; init; }
        [Required]
        public string Code { get; init; }
    }
}

