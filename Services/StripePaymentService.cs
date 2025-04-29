using Stripe;
using Stripe.Checkout;
using System.Collections.Generic;


namespace WattWise.Services
{
    public class StripePaymentService
    {
        private readonly string _secretKey;

        public StripePaymentService(IConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration));
            }

            _secretKey = configuration["Stripe:SecretKey"] ?? throw new InvalidOperationException("Stripe:SecretKey is not configured.");
            StripeConfiguration.ApiKey = _secretKey;
        }

        public async Task<string> CreateCheckoutSession(decimal amount, string currency, string successUrl, string cancelUrl)
        {
            var options = new SessionCreateOptions
            {
                PaymentMethodTypes = new List<string> { "card" },
                LineItems = new List<SessionLineItemOptions>
                   {
                       new SessionLineItemOptions
                       {
                           PriceData = new SessionLineItemPriceDataOptions
                           {
                               Currency = currency,
                               ProductData = new SessionLineItemPriceDataProductDataOptions
                               {
                                   Name = "WattWise Subscription",
                               },
                               UnitAmountDecimal = amount * 100, // Amount in cents  
                           },
                           Quantity = 1,
                       },
                   },
                Mode = "payment",
                SuccessUrl = successUrl,
                CancelUrl = cancelUrl,
            };
            var service = new SessionService();
            Session session = await service.CreateAsync(options);
            return session.Url;
        }
    }
}
