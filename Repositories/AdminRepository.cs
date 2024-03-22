using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class AdminRepository:Repositorybase<Admin>,IAdminRepository
    {
      
        public AdminRepository(RepositoryContext context):base(context)
        {
            
        }

        public async Task<Admin> GetAdminById(Guid id, bool track)
            =>await base.FindByCondition(u=>u.Id.Equals(id.ToString()),track).SingleOrDefaultAsync();
        
    }
}