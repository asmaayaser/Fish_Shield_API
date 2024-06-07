using Stripe.Checkout;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
	public interface IStripePaymentService
	{
		Task<string> CreateCheckoutSession(string userId,string successUrl, string cancelUrl);
		Task SuccessPayment(string SessionId);
		Task CancelledPayment(string SessionId);
	}
}
