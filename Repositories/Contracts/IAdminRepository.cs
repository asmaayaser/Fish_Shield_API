using CORE.Models;

namespace Repositories.Contracts
{
    public interface IAdminRepository
    {
        Task<Admin> GetAdminById(Guid id, bool track);
    }
}
