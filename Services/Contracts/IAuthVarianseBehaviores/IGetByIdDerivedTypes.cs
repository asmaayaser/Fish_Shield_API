using Services.DTO;

namespace Services.Contracts.IAuthVarianseBehaviores
{
    public interface IGetByIdDerivedTypes
    {
        Task<UserForReturnDto> GetById(Guid id, bool track);
    }
}
