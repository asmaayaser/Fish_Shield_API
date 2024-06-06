using System.ComponentModel.DataAnnotations;

namespace Services.DTO
{
    public record ForgetPasswordDto([Required, EmailAddress] string Email);
}

