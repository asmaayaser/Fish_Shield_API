using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Contracts
{
    public interface IDetectDiseaseRepository
    {
        DetectDisease Create(string farmOwnerId, DetectDisease detect);
    }
}