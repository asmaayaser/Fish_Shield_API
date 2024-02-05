using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Contracts
{
    public interface IDiseaseRepository
    {
        IEnumerable<FishDisease> GetAll(bool track);
        FishDisease GetDisease(int id,bool track);
        void Create(FishDisease entity);
    }
}