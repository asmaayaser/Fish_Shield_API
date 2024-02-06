using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
    
        private readonly Lazy<IDetectDiseaseRepository> _detectDiseaseRepository;
        
         // same Function as using Lazy Class
        //public  IDetectDiseaseRepository _detectorRepository { 
        //    get {
        //    if (_detectorRepository == null)
        //            _detectorRepository=new DetectDiseaseRepository(context);

        //        return _detectorRepository;
        //    }
        //    set {
        //    } 
        //}
        private readonly Lazy<IDiseaseRepository> _diseaseRepository;
        private readonly RepositoryContext context;

        public RepositoryManager(RepositoryContext context)
        {
           

            _detectDiseaseRepository= new Lazy<IDetectDiseaseRepository>(()=>new DetectDiseaseRepository(context));
            _diseaseRepository= new Lazy<IDiseaseRepository>(() =>new DiseaseRepository(context));
            this.context = context;
        }





        public IDetectDiseaseRepository DetectDisease =>_detectDiseaseRepository.Value;
        public IDiseaseRepository Diseases => _diseaseRepository.Value;
        
        public void Save()=>context.SaveChanges();
        
    }
}