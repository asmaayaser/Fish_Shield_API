using Microsoft.AspNetCore.Identity;
using Services.DTO;

namespace Services.Contracts
{
    public interface IDoctorService
    {
        Task<IdentityResult> Register(DoctorForRegistrationDto dto);
    }
}
