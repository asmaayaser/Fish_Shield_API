using CORE.Models;
using CORE.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IAppUser
    {
        Task<PagedList<AppUser>> GetAllUsersAsync(AppUserParameters appUserParameters,bool track);
        Task<IEnumerable<AppUser>> DeleteUsers(List<string> usersIDs);
        Task DisableAccounts(List<string> usersIDs);
        Task<AppUser> GetUserByEmail(string email, bool track);
    }
}
