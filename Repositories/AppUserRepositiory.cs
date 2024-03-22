using CORE.Models;
using CORE.Shared;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class AppUserRepositiory : Repositorybase<AppUser>, IAppUser
    {
        public AppUserRepositiory(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<AppUser>> DeleteUsers(List<string> usersIDs)
        {
            var users =await base.FindByCondition(u=>usersIDs.Contains(u.Id),TrackChanges:true).ToListAsync();
           
            foreach (var user in users)
                  user.isDeleted = true;
           
            return users;

        }

        public async Task DisableAccounts(List<string> usersIDs)
        {
            var users = await base.FindByCondition(u => usersIDs.Contains(u.Id), TrackChanges: true).ToListAsync();

            foreach (var user in users)
                user.Disabled = !user.Disabled;

            
        }

        public async Task<PagedList<AppUser>> GetAllUsersAsync(AppUserParameters appUserParameters, bool trak)
        {
            IQueryable<AppUser> users;
            if (appUserParameters.Discriminator is not null)
                users = base.FindByCondition(u => (u.Discriminator == appUserParameters.Discriminator), TrackChanges: trak);
            else
               users =  base.FindAll(TrackChanges: trak);

            if (!string.IsNullOrWhiteSpace(appUserParameters.UsernameSearchTerm))
            {
                var searchTermlower=appUserParameters.UsernameSearchTerm.Trim().ToLower();

               users=users.Where(u => u.UserName.ToLower().Contains(searchTermlower));
            }

             var result=  await users.OrderBy(u => u.UserName).ToListAsync();


            return PagedList<AppUser>.ToPagedList(result, appUserParameters.PageNumber, appUserParameters.PageSize);
        }

      
    }
}
