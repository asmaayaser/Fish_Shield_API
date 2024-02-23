using CORE.Models;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class FarmOwnerRepository:Repositorybase<FarmOwner>,IFarmOwnerRepository
    {
       

        public FarmOwnerRepository(RepositoryContext context):base(context) { }
        
    }
}