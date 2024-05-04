using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class PaymentUserAccountRepositiory : Repositorybase<PaymentUserAccount>, IPaymentUserRepository
    {
        public PaymentUserAccountRepositiory(RepositoryContext context) : base(context)
        {
        }

        public async Task<PaymentUserAccount> GetPaymentUserAccountById(Guid id, bool track)
       =>await base.FindByCondition(u=>u.Id.Equals(id.ToString()),track).SingleOrDefaultAsync();

        public async Task<IEnumerable<PaymentUserAccount>> DeleteUsers(List<string> usersIDs)
        {
            var users = await base.FindByCondition(u => usersIDs.Contains(u.Id), TrackChanges: true).ToListAsync();

            foreach (var user in users)
                user.isDeleted = true;

            return users;

        }
    }
}
