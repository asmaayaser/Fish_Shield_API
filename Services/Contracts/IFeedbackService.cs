using CORE.Shared;
using Services.DTO;

namespace Services.Contracts
{
    public interface IFeedbackService
    {
        Task InsertFeedback(FeedbackForCreationDto feedback);
        Task<(IEnumerable<FeedbackForReturnDto> feedbacks,MetaData metaInfo)> GetAllFeedbacks(FeedbackParameters feedbackParameters,bool track);
        Task DeleteFeedBacks(HashSet<int> feedsIDS);
    }
}