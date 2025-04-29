namespace WattWise.Models
{
    public class StripeEventTypes
    {
        public const string PaymentIntentSucceeded = "payment_intent.succeeded";
        public const string PaymentIntentPaymentFailed = "payment_intent.payment_failed";
        public const string CheckoutSessionCompleted = "checkout.session.completed";
        public const string InvoicePaymentSucceeded = "invoice.payment_succeeded";
        public const string InvoicePaymentFailed = "invoice.payment_failed";
        // Add more Stripe events here as needed
    }
}
