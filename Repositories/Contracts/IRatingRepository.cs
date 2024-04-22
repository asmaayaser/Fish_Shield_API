using CORE.Models;

namespace Repositories.Contracts
{
    public interface IRatingRepository 
    {
        void PostRating(Rating newRate);
        Task<decimal> CalculateRating(Guid id);
    }
}
