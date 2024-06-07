using CORE.Models;
using CORE.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Contracts
{
    public interface IDiseaseRepository
    {
        PagedList<FishDisease> GetAll(FishDiseaseParameters fishDiseaseParameters,bool track);
        PagedList<FishDisease> GetAllPartial(FishDiseaseParameters fishDiseaseParameters, bool track);
        FishDisease GetDisease(int id,bool track);
        FishDisease GetDiseaseByName(string name,bool track);
        void Create(FishDisease entity);
        
    }
}