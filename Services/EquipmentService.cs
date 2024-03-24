using AutoMapper;
using CORE.Contracts;
using CORE.Exceptions;
using CORE.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;

namespace Services
{
    public sealed class EquipmentService : IEquipmentService
    {
        public readonly IRepositoryManager manager;
        private readonly ILoggerManager logger;
        private readonly IMapper mapper;
        private readonly IIOService ioService;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly IWebHostEnvironment webHostEnvironment;

        public EquipmentService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper, IIOService ioService, IHttpContextAccessor httpContextAccessor)
        {

            manager = repository;
            this.logger = logger;
            this.mapper = mapper;
            this.ioService = ioService;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task<EquipmentDto> CreateEquipment(EquipmentForCreationDto dto)
        {
            var Entity = mapper.Map<Equipment>(dto);
            manager.equipment.Create(Entity);
            await manager.SaveAsync();
            var RelativePath = await ioService.uploadImage("Images/Equipment", dto.PhotoPath, $"{Entity.ID}");
            var PathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{RelativePath}";
            Entity.PhotoPath = PathToStoredInDB;
            await manager.SaveAsync();
            var Res = mapper.Map<EquipmentDto>(Entity);
            return Res;
        }
        public EquipmentDto GetEquipment(int id, bool track)
        {
            var Equipment = manager.equipment.GetEquipment(id, track);

            if (Equipment is null)
                throw new EquipmentNotFoundException();

            var EquipmentDTO = mapper.Map<EquipmentDto>(Equipment);

            return EquipmentDTO;
        }
        public async Task<EquipmentDto> UpdateEquipment(EquipmentForUpdateDto dto)
        {
            var existingEquipment = manager.equipment.GetEquipment(dto.ID, track: false);

            if (existingEquipment == null)
            {
                throw new EquipmentNotFoundException();
            }

            mapper.Map(dto, existingEquipment);


            var relativePath = await ioService.uploadImage("Images/Equipment", dto.PhotoPath, $"{existingEquipment.ID}");
            var pathToStoredInDB = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}{relativePath}";
            existingEquipment.PhotoPath = pathToStoredInDB;


            manager.equipment.Update(existingEquipment);
            await manager.SaveAsync();

            var result = mapper.Map<EquipmentDto>(existingEquipment);
            return result;
        }
        public IEnumerable<EquipmentDto> GetALLEquipment(bool track)
        {
            var all = manager.equipment.GetAll(track);

            var Res = mapper.Map<IEnumerable<EquipmentDto>>(all);
            return Res;
        }

        public async Task<EquipmentDto> DeleteEquipment(EquipmentForDeleteDto dto)
        {
            var existingEquipment = manager.equipment.GetEquipment(dto.ID, track: false);

            if (existingEquipment == null)
            {
                throw new EquipmentNotFoundException();
            }

            manager.equipment.Delete(existingEquipment);
            await manager.SaveAsync();

            var result = mapper.Map<EquipmentDto>(existingEquipment);
            return result;
        }
        public IEnumerable<EquipmentDto> GetALLEquipmentForOwner(string OwnerId, bool track)
        {
            var all = manager.equipment.GetAllEquForOwner(OwnerId);

            var Res = mapper.Map<IEnumerable<EquipmentDto>>(all);
            return Res;
        }

    }
}