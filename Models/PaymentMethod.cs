using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; } // Primary Key
        
        public string? Method { get; set; } // Stripe Payment Method ID
        
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public ApplicationUser? User { get; set; } // Navigation property to ApplicationUser
    }
}
