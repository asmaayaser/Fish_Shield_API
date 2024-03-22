using Microsoft.AspNetCore.Identity;
using Services.DTO;

namespace Services.Contracts.IAuthVarianseBehaviores
{
    public interface IRegistration
    {
        Task<IdentityResult> Register(UserForRegestrationDto userForRegestration);
    }
}
