using CORE.Models;

namespace Repositories.Contracts
{
    public interface IFarmOwnerRepository
    {
        Task<FarmOwner> GetFarmOwnerById(Guid id, bool track);
    }
}
