using Services.DTO;

namespace Services.Contracts.IAuthVarianseBehaviores
{
    public interface IGetAllDerivedTypes
    {
        Task<IEnumerable<UserForReturnDto>> GetAllDreivedTypesAsync(bool track);
    }
}
