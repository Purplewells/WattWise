using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class StripeWebhookLog
    {
        [Key]
        public int WebhookLogId { get; set; }

        public string? EventId { get; set; }       // Stripe Event ID
        public required string EventType { get; set; }      // Stripe Event Type (e.g., payment_intent.succeeded)
        public string? Payload { get; set; }        // Full JSON payload received
        public DateTime ReceivedDate { get; set; }   // Timestamp when webhook was received
        public bool ProcessedSuccessfully { get; set; }  // Whether our app processed the event ok
        public string? ProcessingNotes { get; set; }      // Optional notes (errors, etc.)
    }
}
