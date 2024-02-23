using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class FeedbackRepository : Repositorybase<FeedBack>, IFeedbackRepository
    {
        public FeedbackRepository(RepositoryContext context) : base(context)
        {
        }


        public async Task CreateFeedback(FeedBack feedBack)=> base.Add(feedBack);
        public async Task<IEnumerable<FeedBack>> GetFeedBacks(bool track)=>await base.FindAll(track).ToListAsync();
       
    }
}
