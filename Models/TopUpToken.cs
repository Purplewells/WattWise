using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class TopUpToken
    {
        [Key]
        public int TokenId { get; set; }

        // Foreign key to Meter
        public int MeterId { get; set; } // Foreign key to Meter
        public Meter? Meter { get; set; } // Navigation property to Meter


        [Required]
        public decimal Amount { get; set; }

        [Required]
        public required string Token { get; set; }

        public DateTime LoggedDate { get; set; } = DateTime.UtcNow;


        // link to ApplicationUser
        public ApplicationUser? Customer { get; set; } // Navigation property to ApplicationUser
    }
}
