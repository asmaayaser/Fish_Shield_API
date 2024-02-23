using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
    [Route("api/Disease")]
    [ApiController]
   
    public class DiseaseController : ControllerBase
    {
        private readonly IServiceManager service;
        public DiseaseController(IServiceManager service)
        {
            this.service = service;
        }

        #region Get
        [HttpGet]
        public IActionResult GetAll()
        {
            var res = service.diseaseService.GetALLDisease(track: false);
            return Ok(res);
        }

        [HttpGet("{id:int}",Name ="GetById")]
        public IActionResult Get(int id)
        {
           var Res= service.diseaseService.GetDisease(track: false, id: id);
           return Ok(Res);
        }

        #endregion

        #region Post
        //[Authorize(Roles = "Admin")]
        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> Post([FromForm]DiseaseForCreationDto dto)
        {
            var Result =await service.diseaseService.Create(dto);

            return CreatedAtRoute("GetById", new { id = Result.ID }, Result);
        }

        #endregion
        #region Put


        #endregion
        #region Delete


        #endregion
    }
}
