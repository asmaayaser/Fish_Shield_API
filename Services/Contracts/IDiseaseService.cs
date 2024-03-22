using CORE.Models;
using CORE.Shared;
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
        (IEnumerable<DiseaseDto>diseases,MetaData meta) GetALLDisease(FishDiseaseParameters fishDiseaseParameters,bool track);
        DiseaseDto GetDisease(int id,bool track); 
        Task<DiseaseDto> Create(DiseaseForCreationDto dto);
    }

}
