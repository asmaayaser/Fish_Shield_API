using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IDetectDiseaseRepository DetectDisease { get; }
        IDiseaseRepository Diseases { get; }
        IDoctorRepository Doctors { get; }
        IAdminRepository Admins { get; }
        IFarmOwnerRepository farmOwner { get; }
        IFeedbackRepository feedbackRepository { get; }
        Task SaveAsync();
    }
}