using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class Payment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }  // Link to your Customer table

        [Required]
        public int MeterId { get; set; }  // Link to the Meter being topped up

        [Required]
        public decimal Amount { get; set; }

        public string? Currency { get; set; } = "GHS"; // Default currency, can be changed based on user preference

        public DateTime PaymentDate { get; set; } = DateTime.UtcNow;

        [Required]
        [MaxLength(100)]
        public string? PaymentProvider { get; set; } // e.g., "Stripe", "PayPal", etc.

        [Required]
        [MaxLength(200)]
        public string? PaymentReference { get; set; } // Stripe's charge ID, PayPal's transaction ID, etc.

        public required string PaymentStatus { get; set; } // "Pending", "Succeeded", "Failed"

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public DateTime? CompletedDate { get; set; } = DateTime.UtcNow;

        public ApplicationUser? User { get; set; } // Navigation property to ApplicationUser
    }
}
