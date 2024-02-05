using Microsoft.AspNetCore.Identity;
using Services.DTO;

namespace Services.Contracts
{
    public interface IAdminService
    {
        Task<IdentityResult> Register(AdminForRegistrationDto dto);
    }
}
