using Repositories.Contracts;
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
        #region obseleted
        //IAdminService adminService { get; }
        //IDoctorService doctorService { get; }
        //IFarmOwnerService farmOwnerService { get; }

        #endregion
        IAuthentication AuthenticationService {  get; }
        IFeedbackService feedbackService { get; }

        void SetFarmOwnerStrategy();
        void SetAdminStrategy();
        void SetDoctorStrategy();
    }
}
