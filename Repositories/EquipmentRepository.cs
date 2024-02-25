using CORE.Exceptions;
using CORE.Models;
using Repositories.Context;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class EquipmentRepository: Repositorybase<Equipment>, IEquipmentRepository
    {
        public EquipmentRepository(RepositoryContext context):base(context) { }
        public void Create(Equipment Equipment) => base.Add(Equipment);
        public void Update(Equipment Equipment) => base.Update(Equipment);

        public Equipment GetEquipment(int id, bool track)
               => base.FindByCondition(e => e.ID == id, track).SingleOrDefault();
        public void Delete(Equipment Equipment) => base.Delete(Equipment);

        public IEnumerable<Equipment> GetAll(bool track)
            => base.FindAll(track);



    }
}
