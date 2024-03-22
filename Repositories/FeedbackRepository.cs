using CORE.Models;
using CORE.Shared;
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

        public async Task DeleteFeedback(HashSet<int> ids)
        {
            var feedbacks = base.FindByCondition(f => ids.Contains(f.Id),TrackChanges:true);

           foreach(var feed in feedbacks)
                feed.isDeleted = true;
           
        }

        public async Task<PagedList<FeedBack>> GetFeedBacks(FeedbackParameters feedbackParameters, bool track)
        {
           var entities= await base.FindByCondition(f=>f.DateTime >= feedbackParameters.StartDate && f.DateTime<=feedbackParameters.EndDate,track)
                                    .OrderByDescending(f=>f.DateTime)
                                    .ToListAsync();

            return PagedList<FeedBack>.ToPagedList(entities, feedbackParameters.PageNumber,feedbackParameters.PageSize);

        }

        
    }
}
