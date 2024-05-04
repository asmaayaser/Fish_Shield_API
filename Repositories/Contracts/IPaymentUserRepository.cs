using CORE.Models;

namespace Repositories.Contracts
{
    public interface IPaymentUserRepository
    {
        Task<PaymentUserAccount> GetPaymentUserAccountById(Guid id, bool track);
        Task<IEnumerable<PaymentUserAccount>> DeleteUsers(List<string> usersIDs);
    }
}
