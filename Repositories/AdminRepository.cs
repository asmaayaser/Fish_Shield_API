using CORE.Models;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class AdminRepository:Repositorybase<Admin>,IAdminRepository
    {
      
        public AdminRepository(RepositoryContext context):base(context)
        {
            
        }
    }
}