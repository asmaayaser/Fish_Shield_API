using AutoMapper;
using CORE.Exceptions;
using CORE.Models;
using Repositories.Contracts;
using Services.Contracts;
using Services.DTO;

namespace Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IRepositoryManager manager;
        private readonly IMapper mapper;

        public FeedbackService(IRepositoryManager manager,IMapper mapper)
        {
            this.manager = manager;
            this.mapper = mapper;
        }


        public async Task<IEnumerable<FeedbackForReturnDto>> GetAllFeedbacks(bool track)
        {
           var FeedsList=  await manager.feedbackRepository.GetFeedBacks(track);
            if (FeedsList.Count() <= 0)
                throw new NoFeedsFoundedInDB();
            return mapper.Map<IEnumerable<FeedbackForReturnDto>>(FeedsList);
        }

        public async Task InsertFeedback(FeedbackForCreationDto feedback)
        {
            var FeedEntity = mapper.Map<FeedBack>(feedback);
            await manager.feedbackRepository.CreateFeedback(FeedEntity);
            await manager.SaveAsync();
        }
    }
}
