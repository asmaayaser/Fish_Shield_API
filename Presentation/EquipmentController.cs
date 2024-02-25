using Microsoft.AspNetCore.Mvc;
using Presentation.ValidationFilter;
using Services.Contracts;
using Services.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation
{

    [Route("api/{OwnerID:guid}/Equipment")]
    [ApiController]

    public class EquipmentController : ControllerBase
    {
        private readonly IServiceManager service;
        public EquipmentController(IServiceManager service)
        {
            this.service = service;
        }

        #region Get
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = service.equipmentService.GetALLEquipment(track: false);
            return Ok(res);
        }
        [HttpGet("Owner")]
        public IActionResult GetAllByOwnerID(string id)
        {
            var Res = service.equipmentService.GetALLEquipmentForOwner(track: false, OwnerId: id);
            return Ok(Res);
        }

        [HttpGet("{id:int}", Name = "GetById1")]
        public IActionResult Get(int id)
        {
            var Res = service.equipmentService.GetEquipment(track: false, id: id);
            return Ok(Res);
        }

        #endregion

        #region Post
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Post([FromForm] EquipmentForCreationDto dto)
        {
            var Result = await service.equipmentService.CreateEquipment(dto);
            return Ok(Result);

        }

        #endregion
        #region Put
        [HttpPut]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Update([FromForm] EquipmentForUpdateDto dto)
        {
            var Result = await service.equipmentService.UpdateEquipment(dto);
            return Ok(Result);
        }

        #endregion
        #region Delete
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dto = new EquipmentForDeleteDto { ID = id };
            var Result = await service.equipmentService.DeleteEquipment(dto);

            return Ok(Result);
        }

        #endregion
    }
}
