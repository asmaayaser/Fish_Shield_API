﻿using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class FarmOwnerRepository:Repositorybase<FarmOwner>,IFarmOwnerRepository
    {
       

        public FarmOwnerRepository(RepositoryContext context):base(context) { }

        public async Task<FarmOwner> GetFarmOwnerById(Guid id, bool track)
            =>await base.FindByCondition(u=>u.Id==id.ToString(), track).FirstOrDefaultAsync();
       
    }
}