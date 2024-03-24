using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IEquipmentRepository
    {
        public void Create(Equipment Equipment);
        public void Update(Equipment Equipment);

        Equipment GetEquipment(int id, bool track);

        public void Delete(Equipment Equipment);

        public IEnumerable<Equipment> GetAll(bool track);
        public IEnumerable<Equipment> GetAllEquForOwner(string ownerid);
    }
}