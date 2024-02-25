﻿using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public sealed class RepositoryManager : IRepositoryManager
    {
    
        
        private readonly Lazy<IDetectDiseaseRepository> _detectDiseaseRepository;
        private readonly Lazy<IDiseaseRepository> _diseaseRepository;
        private readonly Lazy<IDoctorRepository> _doctorRepository;
        private readonly Lazy<IAdminRepository> _adminRepository;
        private readonly Lazy<IFarmOwnerRepository> _farmOwnerRepository;
        private readonly Lazy<IFeedbackRepository> _feedbackRepository;
        private readonly Lazy<IEquipmentRepository> _equipmentRepository;

        private readonly RepositoryContext context;

        public RepositoryManager(RepositoryContext context)
        {
           

            _detectDiseaseRepository= new Lazy<IDetectDiseaseRepository>(()=>new DetectDiseaseRepository(context));
            _diseaseRepository= new Lazy<IDiseaseRepository>(() =>new DiseaseRepository(context));
            _doctorRepository=new Lazy<IDoctorRepository>(()=>new DoctorRepository(context));
            _adminRepository = new Lazy<IAdminRepository>(() => new AdminRepository(context));
            _farmOwnerRepository=new Lazy<IFarmOwnerRepository>(()=>new FarmOwnerRepository(context));
            _feedbackRepository=new Lazy<IFeedbackRepository>(()=>new FeedbackRepository(context));
            _equipmentRepository=new Lazy<IEquipmentRepository>(new EquipmentRepository(context));
            this.context = context;
        }





        public IDetectDiseaseRepository DetectDisease =>_detectDiseaseRepository.Value;
        public IDiseaseRepository Diseases => _diseaseRepository.Value;
        public IDoctorRepository Doctors => _doctorRepository.Value;
        public IAdminRepository Admins => _adminRepository.Value;
        public IFarmOwnerRepository farmOwner => _farmOwnerRepository.Value;
        public IFeedbackRepository feedbackRepository =>_feedbackRepository.Value;
        public IEquipmentRepository equipment => _equipmentRepository.Value;

        public async Task SaveAsync()=>await context.SaveChangesAsync();
        
    }
}