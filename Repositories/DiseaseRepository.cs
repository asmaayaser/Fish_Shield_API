using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class DiseaseRepository : Repositorybase<FishDisease>, IDiseaseRepository
    {
        public DiseaseRepository(RepositoryContext context) : base(context)
        {
          // context.FishDiseases.Where(d=>d.ID==1).Select (d => new {d.ID, Ag=d.CausativeAgents.Select(a=>a.Agents) ,})
        }

        public void Create(FishDisease entity)=>base.Add(entity);


        public IEnumerable<FishDisease> GetAll(bool track)
            =>base.FindAll(track).Include(d => d.ImpactOnAquacultures)
            .Include(d => d.PreventionAndControlls)
            .Include(d => d.CausativeAgents)
            .Include(d => d.ClinicalSigns)
            .Include(d => d.Diagnosis)
            .Include(d => d.RecommandationActions)
            .Include(d => d.Treatment)
            .OrderBy(d=>d.Name).ToList();
       




        public FishDisease GetDisease(int id,bool track)
            => base.FindByCondition(d=>d.ID==id,track).Include(d => d.ImpactOnAquacultures)
            .Include(d => d.PreventionAndControlls)
            .Include(d => d.CausativeAgents)
            .Include(d => d.ClinicalSigns)
            .Include(d => d.Diagnosis)
            .Include(d => d.RecommandationActions)
            .Include(d => d.Treatment).SingleOrDefault();

       
    }
}