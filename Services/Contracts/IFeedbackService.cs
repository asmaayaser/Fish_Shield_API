using Services.DTO;

namespace Services.Contracts
{
    public interface IFeedbackService
    {
        Task InsertFeedback(FeedbackForCreationDto feedback);
        Task<IEnumerable<FeedbackForReturnDto>> GetAllFeedbacks(bool track);
    }
}