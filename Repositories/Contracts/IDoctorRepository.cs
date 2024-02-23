using CORE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IDoctorRepository
    {
       Task<IEnumerable<Doctor>> GetAllDoctors(bool track); 
        Task<Doctor> GetDoctorById(Guid id,bool track);
    }
}
