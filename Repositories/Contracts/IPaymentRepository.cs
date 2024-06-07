using CORE.Models;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
	public interface IPaymentRepository
	{
		Task createPayment(string userId,PaymentRecord paymentRecord);
		Task<PaymentRecord> GetById(string SessionId, bool track);
	}
}
