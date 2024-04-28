using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public class DoctorRepository :Repositorybase<Doctor>, IDoctorRepository
    {
        public DoctorRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Doctor>> GetAllDoctors(bool track)=>await base.FindAll(track).ToListAsync() ;

        public async Task<Doctor> GetDoctorById(Guid id, bool track) => await base.FindByCondition(d => d.Id.Equals(id.ToString()), track).SingleOrDefaultAsync();

        public async Task UpdateDoctorData(Doctor doctor)=>base.Update(doctor);
       
    }
}
