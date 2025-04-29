using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class CreditUpdateLog
    {
        // define the properties for the CreditUpdateLog class
        [Key]
        public int CreditUpdateLogId { get; set; } // Unique identifier for the credit update log entry
        public int MeterId { get; set; } // Foreign key to the Meter
        public Meter? Meter { get; set; } // Navigation property to the Meter
        public DateTime UpdateDate { get; set; } = DateTime.Now; // Date and time of the credit update
        public decimal Amount { get; set; } = 0.0m; // Amount of credit added or deducted
        public string? Description { get; set; } // Description of the credit update
        public string? TransactionType { get; set; } // Type of transaction (e.g., "Credit", "Debit")
        public string? PaymentMethod { get; set; } // Payment method used for the transaction (e.g., "Credit Card", "Cash")
        public string? Status { get; set; } // Status of the transaction (e.g., "Pending", "Completed", "Failed")

    }
}
