//using Microsoft.AspNetCore.Mvc;
//using Stripe;
//using System.IO;
//using System.Threading.Tasks;
//using Microsoft.Extensions.Configuration;
//using System;

//using Stripe.Checkout;
//using WattWise.Models;
//using Microsoft.Build.Framework;
//using ILogger = Microsoft.Build.Framework.ILogger;
//using WattWise.Data;
//using Microsoft.EntityFrameworkCore;

//namespace WattWise.api.stripe.webhook
//{
//    [Route("api/stripe/webhook")]
//    [ApiController]
//    public class StripeWebhookController : Controller
//    {
//        private readonly IConfiguration _configuration;
//        private readonly ApplicationDBContext _dbContext;
//        private readonly ILogger<StripeWebhookController> _logger; // Use generic ILogger for this class

//        public StripeWebhookController(IConfiguration configuration, ApplicationDBContext dbContext, ILogger<StripeWebhookController> logger)
//        {
//            _configuration = configuration;
//            _dbContext = dbContext;
//            _logger = logger; // Assign the logger
//        }

//        [HttpPost]
//        public async Task<IActionResult> HandleStripeWebhook()
//        {
//            var json = await new StreamReader(HttpContext.Request.Body).ReadToEndAsync();

//            var stripeSignature = Request.Headers["Stripe-Signature"];
//            var endpointSecret = _configuration["Stripe:WebhookSecret"];

//            Event stripeEvent;

//            try
//            {
//                stripeEvent = EventUtility.ConstructEvent(
//                    json,
//                    stripeSignature,
//                    endpointSecret
//                );

//                // Create log record
//                var webhookLog = new StripeWebhookLog
//                {
//                    EventId = stripeEvent.Id,
//                    EventType = stripeEvent.Type,
//                    Payload = json,
//                    ReceivedDate = DateTime.UtcNow,
//                    ProcessedSuccessfully = false, // Update after processing
//                    ProcessingNotes = string.Empty
//                };
//                _dbContext.StripeWebhookLogs.Add(webhookLog);
//                await _dbContext.SaveChangesAsync();

//                // Handle specific event types
//                if (stripeEvent.Type == StripeEventTypes.PaymentIntentSucceeded)
//                {
//                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

//                    if (paymentIntent != null)
//                    {
//                        var payment = await _dbContext.Payments
//                            .FirstOrDefaultAsync(p => p.PaymentReference == paymentIntent.Id);

//                        if (payment != null)
//                        {
//                            payment.PaymentStatus = "Succeeded";
//                            payment.PaymentDate = DateTime.UtcNow;
//                            //payment.RawResponse = json;

//                            await _dbContext.SaveChangesAsync();
//                        }
//                    }
//                }
//                else if (stripeEvent.Type == StripeEventTypes.PaymentIntentPaymentFailed)
//                {
//                    var paymentIntent = stripeEvent.Data.Object as PaymentIntent;

//                    if (paymentIntent != null)
//                    {
//                        var payment = await _dbContext.Payments
//                            .FirstOrDefaultAsync(p => p.PaymentReference == paymentIntent.Id);

//                        if (payment != null)
//                        {
//                            payment.PaymentStatus = "Failed";
//                            //payment.RawResponse = json;

//                            await _dbContext.SaveChangesAsync();
//                        }
//                    }
//                }

//                return Ok();
//            }
//            catch (StripeException ex) // Fix: Declare 'ex' here
//            {
//                _logger.LogError(ex, "Stripe webhook error"); // Fix: Use the injected logger

//                var errorLog = new StripeWebhookLog
//                {
//                    EventId = "Unknown",
//                    EventType = "ParseError",
//                    Payload = json,
//                    ReceivedDate = DateTime.UtcNow,
//                    ProcessedSuccessfully = false,
//                    ProcessingNotes = ex.Message
//                };
//                _dbContext.StripeWebhookLogs.Add(errorLog);
//                await _dbContext.SaveChangesAsync();

//                return BadRequest();
//            }


//        }
//    }
//}
