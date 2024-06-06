using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;

namespace Repositories
{
    public class RatingRepository : Repositorybase<Rating>, IRatingRepository
    {
        public RatingRepository(RepositoryContext context) : base(context)
        {
        }

        public async Task<decimal> CalculateRating(Guid id)
        {
            var rate = await base.FindByCondition(r => r.DoctorId.Equals(id.ToString()), TrackChanges: false).AverageAsync(a=>a.Rate);
            #region old code fashion
            //  var Rates= await base.FindByCondition(r => r.DoctorId == id.ToString(),TrackChanges:false).ToListAsync();
            //  var RatingCount= Rates.Count();

            //    if(RatingCount == 0) 
            //        return 0;

            //    decimal sum = 0;
            //    foreach (var Rating in Rates)
            //        sum += Rating.Rate;

            //    return Math.Round(sum / RatingCount); 
            #endregion
            return rate;
        }

        public void PostRating(Rating newRate) => Add(newRate);

    }
}
