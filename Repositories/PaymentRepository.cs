using CORE.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
	public class PaymentRepository : Repositorybase<PaymentRecord>, IPaymentRepository
	{
		public PaymentRepository(RepositoryContext context) : base(context)
		{
		}

		public Task createPayment(string userId, PaymentRecord paymentRecord)
		{
			paymentRecord.OwnerId = userId;
			base.Add(paymentRecord);
			return Task.CompletedTask;
		}

		public async Task<PaymentRecord> GetById(string SessionId,bool track)
		=> await base.FindByCondition(s=>s.StripeSessionId==SessionId,TrackChanges:track).SingleOrDefaultAsync();
	}
}
