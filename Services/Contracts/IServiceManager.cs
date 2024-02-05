using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface IServiceManager
    {
        IDiseaseService diseaseService { get; }
        IDetectDiseaseService detectDiseaseService { get; }
        IAdminService adminService { get; }
        IDoctorService doctorService { get; }
        IFarmOwnerService farmOwnerService { get; }
    }
}
