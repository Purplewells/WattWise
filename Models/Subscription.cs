using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class Subscription
    {
        [Key]
        public int SubscriptionId { get; set; } // Primary Key
        public string? SubscriptionMech { get; set; } // Stripe Subscription ID
        public string? CustomerId { get; set; } // Stripe Customer ID
        public string? Status { get; set; } // e.g., active, canceled, etc.
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? EndDate { get; set; } // Optional end date for canceled subscriptions
        public ApplicationUser? User { get; set; } // Navigation property to ApplicationUser
    }
}
