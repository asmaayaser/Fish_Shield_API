using Microsoft.AspNetCore.Identity;
using Services.DTO;

namespace Services.Contracts.IAuthVarianseBehaviores
{
    public interface IGetAllDerivedTypes
    {
        Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track);
    }
    public interface IUpdateUserData
    {
        Task<IdentityResult> UpdateUserDataAsync(UserForUpdateDto userForUpdateDto);
    }
   
}
