using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CORE.Models;
using CORE.Shared;
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


        public PagedList<FishDisease> GetAll(FishDiseaseParameters fishDiseaseParameters, bool track)
        {
            List<FishDisease> All;
            if(!string.IsNullOrWhiteSpace(fishDiseaseParameters.diseaseNameSearchTerm) )
            All=  base.FindByCondition(d=>d.Name.Contains(fishDiseaseParameters.diseaseNameSearchTerm),track).Include(d => d.ImpactOnAquacultures)
            .Include(d => d.PreventionAndControlls)
            .Include(d => d.CausativeAgents)
            .Include(d => d.ClinicalSigns)
            .Include(d => d.Diagnosis)
            .Include(d => d.RecommandationActions)
            .Include(d => d.Treatment)
            .OrderBy(d => d.Name).ToList();
            else
                All = base.FindAll(track).Include(d => d.ImpactOnAquacultures)
           .Include(d => d.PreventionAndControlls)
           .Include(d => d.CausativeAgents)
           .Include(d => d.ClinicalSigns)
           .Include(d => d.Diagnosis)
           .Include(d => d.RecommandationActions)
           .Include(d => d.Treatment)
           .OrderBy(d => d.Name).ToList();
            return PagedList<FishDisease>.ToPagedList(All,fishDiseaseParameters.PageNumber,fishDiseaseParameters.PageSize);
        }



        public FishDisease GetDisease(int id,bool track)
            => base.FindByCondition(d=>d.ID==id,track).Include(d => d.ImpactOnAquacultures)
            .Include(d => d.PreventionAndControlls)
            .Include(d => d.CausativeAgents)
            .Include(d => d.ClinicalSigns)
            .Include(d => d.Diagnosis)
            .Include(d => d.RecommandationActions)
            .Include(d => d.Treatment).SingleOrDefault();

        public FishDisease GetDiseaseByName(string name,bool track)
         => base.FindByCondition(d => d.Name.Trim().ToLower().Equals(name.Trim().ToLower()), track).Include(d => d.ImpactOnAquacultures)
            .Include(d => d.PreventionAndControlls)
            .Include(d => d.CausativeAgents)
            .Include(d => d.ClinicalSigns)
            .Include(d => d.Diagnosis)
            .Include(d => d.RecommandationActions)
            .Include(d => d.Treatment).SingleOrDefault();
    }
}