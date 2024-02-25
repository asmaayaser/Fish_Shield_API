using Microsoft.AspNetCore.Http;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IEquipmentService
    {
        IEnumerable<EquipmentDto> GetALLEquipment(bool track);
        Task<EquipmentDto> CreateEquipment(EquipmentForCreationDto dto);
        Task<EquipmentDto> UpdateEquipment(EquipmentForUpdateDto dto);
        Task<EquipmentDto> DeleteEquipment(EquipmentForDeleteDto dto);
        EquipmentDto GetEquipment(int id, bool track);



    }
}
