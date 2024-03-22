using CORE.Shared;
using Microsoft.AspNetCore.Identity;
using Services.Contracts.IAuthVarianseBehaviores;
using Services.DTO;

namespace Services.Contracts
{
    public interface IAuthentication
    {

        IRegistration registration { get; set; }
        Task<IdentityResult> Registration(UserForRegestrationDto userForRegestration);

        IGetAllDerivedTypes getAll { get; set; }
        Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track);

        IGetByIdDerivedTypes getByIdDerivedTypes { get; set; }
        Task<UserForReturnDto> GetByIdDerivedTypeAsync(Guid id, bool track);

        Task<bool> ValidateUser(UserForLoginDto userForLogin);
        Task<TokenDto> CreateToken(bool PopulateExpiration);
        Task<TokenDto> RefreshToken(TokenDto tokenDto);

        Task<bool> ForgotPasswordAsync(ForgetPasswordDto forgetPasswordDto);
        Task<IdentityResult> ResetPasswordAsync(ResetPasswordDto resetPasswordDto);

        Task<(IEnumerable<AppuserForReturnPartial> allusers, MetaData meta)> GetAllUsers(AppUserParameters appUserParameters, bool track);
        Task DeleteUsers(List<string> UsersIds);
        Task DisableOrEnableAccounts(List<string> UsersIds);

    }
}
