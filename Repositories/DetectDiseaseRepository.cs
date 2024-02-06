using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CORE.Models;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class DetectDiseaseRepository : Repositorybase<DetectDisease>, IDetectDiseaseRepository
    {
        public DetectDiseaseRepository(RepositoryContext context) : base(context)
        {
        }
    }
}