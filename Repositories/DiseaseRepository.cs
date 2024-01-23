using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CORE.Models;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class DiseaseRepository : Repositorybase<FishDisease>, IDiseaseRepository
    {
        public DiseaseRepository(RepositoryContext context) : base(context)
        {
        }

        public IEnumerable<FishDisease> GetAll(bool track) => base.FindAll(track).ToList();

        public FishDisease GetDisease(int id,bool track)=>base.FindByCondition(d=>d.ID==id,track).SingleOrDefault();
       
    }
}