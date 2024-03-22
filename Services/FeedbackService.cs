using AutoMapper;
using CORE.Exceptions;
using CORE.Models;
using CORE.Shared;
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

        public async Task DeleteFeedBacks(HashSet<int> feedsIDS)
        {
           await  manager.feedbackRepository.DeleteFeedback(feedsIDS);
           await manager.SaveAsync();
        }

        public async Task<(IEnumerable<FeedbackForReturnDto> feedbacks, MetaData metaInfo)> GetAllFeedbacks(FeedbackParameters feedbackParameters, bool track)
        {
            if (!feedbackParameters.IsValidDateRange)
                throw new InvalidDateRangeBadRequest();

            var FeedsListWithMeta = await manager.feedbackRepository.GetFeedBacks(feedbackParameters, track);
            //if (FeedsListWithMeta.Count() <= 0)
            //    throw new NoFeedsFoundedInDB();
            var feedsDto = mapper.Map<IEnumerable<FeedbackForReturnDto>>(FeedsListWithMeta);

            return (feedbacks:feedsDto,metaInfo:FeedsListWithMeta.MetaInfo) ;
        }

        public async Task InsertFeedback(FeedbackForCreationDto feedback)
        {
            var FeedEntity = mapper.Map<FeedBack>(feedback);
            await manager.feedbackRepository.CreateFeedback(FeedEntity);
            await manager.SaveAsync();
        }

       
    }
}
