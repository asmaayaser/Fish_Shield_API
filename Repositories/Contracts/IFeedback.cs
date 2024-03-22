using CORE.Models;
using CORE.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IFeedbackRepository
    {
        Task CreateFeedback(FeedBack feedBack);
        Task<PagedList<FeedBack>> GetFeedBacks(FeedbackParameters feedbackParameters,bool track);
        Task DeleteFeedback(HashSet<int> ids);
    }
}
