using CORE.Models;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IDiseaseService
    {
        IEnumerable<DiseaseForManipulationDto> GetALLDisease(bool track);
        DiseaseForManipulationDto GetDisease(int id,bool track); 
    }

}
