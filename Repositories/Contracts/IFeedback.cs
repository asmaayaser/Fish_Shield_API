using CORE.Models;
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
        Task<IEnumerable<FeedBack>> GetFeedBacks(bool track);
    }
}
