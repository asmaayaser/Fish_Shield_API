using CORE.Exceptions;
using Microsoft.Extensions.Options;
using Repositories.Contracts;
using Services.Contracts;
using Stripe;
using Stripe.Checkout;


namespace Services
{
	public class StripePaymentService : IStripePaymentService
	{
		private readonly IRepositoryManager manager;

		public StripePaymentService(IOptions<StripeSettings> stripeSettings,IRepositoryManager manager)
		{
			StripeConfiguration.ApiKey = stripeSettings.Value.SecretKey;
			this.manager = manager;
		}

		public async Task CancelledPayment(string SessionId)
		{
			var paymentrecord = await manager.paymentRepository.GetById(SessionId, track: true);
			if (paymentrecord != null)
			{
				paymentrecord.Status = "Cancelled";
				await manager.SaveAsync();
			}
		}

		public async Task<string> CreateCheckoutSession(string userId,string successUrl, string cancelUrl)
		{

		   var user=	 await manager.farmOwner.GetFarmOwnerById(Guid.Parse(userId),track:false);

			if(user == null)
			{
				throw new UserNotFoundException(userId);
			}
			var options = new SessionCreateOptions
			{
				PaymentMethodTypes = new List<string>
			{
				"card",
			},
				LineItems = new List<SessionLineItemOptions>
			{
				new SessionLineItemOptions
				{
					PriceData = new SessionLineItemPriceDataOptions
					{
						UnitAmount = 2000, // For example, $20.00 (this value is in cents)
                        Currency = "usd",
						ProductData = new SessionLineItemPriceDataProductDataOptions
						{
							Name = "Subscription",
						},
					},
					Quantity = 1,
				},
			},
				Mode = "payment",
				SuccessUrl = successUrl,
				CancelUrl = cancelUrl,
			};

			var service = new SessionService();
			Session session = service.Create(options);

			await manager.paymentRepository.createPayment(userId, new CORE.Models.PaymentRecord
			{
				StripeSessionId=session.Id,
				Created = DateTime.UtcNow,
				Status = "Created"
			});
			await manager.SaveAsync();

			return session.Url;
		}

		public async Task SuccessPayment(string SessionId)
		{
			var paymentrecord = await manager.paymentRepository.GetById(SessionId, track: true);
			if(paymentrecord != null)
			{
			  
				paymentrecord.Status = "Success";

				var user = await manager.farmOwner.GetFarmOwnerById(Guid.Parse(paymentrecord.OwnerId), track: true);
				user.isPaid = true;
				user.SubscriptionEndDate = DateTime.UtcNow.AddMonths(1);
				await manager.SaveAsync();
			}
		}
	}

	public class StripeSettings
	{
		public string SecretKey { get; set; }
	}
}
