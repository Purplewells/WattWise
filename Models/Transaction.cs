using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class Transaction
    {
        [Key]
        public int TransactionID { get; set; }
        public DateTime TransactionDate { get; set; } = DateTime.Now;
        public decimal Amount { get; set; } = 0.0m;
        public string? Description { get; set; } // Description of the transaction
        public string? TransactionType { get; set; } // Type of transaction (e.g., "Credit", "Debit")
        public string? PaymentMethod { get; set; } // Payment method (e.g., "Credit Card", "Cash")
        public string? Status { get; set; } // Status of the transaction (e.g., "Pending", "Completed", "Failed")
        public int MeterID { get; set; } // Foreign key to Meter
        public Meter? Meter { get; set; } // Navigation property to Meter

        public string? TransactionReference { get; set; } // Unique reference for the transaction
        //public string? ReceiptURL { get; set; } // URL to the receipt or proof of transaction
        public string? Currency { get; set; } // Currency of the transaction (e.g., "USD", "EUR")
        public string? Notes { get; set; } // Additional notes or comments about the transaction
        public string? Category { get; set; } // Category of the transaction (e.g., "Utilities", "Rent")
        public string? Tags { get; set; } // Tags associated with the transaction (e.g., "Electricity", "Water")
        public string? Location { get; set; } // Location of the transaction (e.g., "Online", "In-Store")

        //public int UserId { get; set; } // Foreign key to ApplicationUser
        //public ApplicationUser? User { get; set; } // Navigation property to ApplicationUser

        //public string? AccountNumber { get; set; } // Account number associated with the transaction
        //public string? BankName { get; set; } // Name of the bank associated with the transaction
        //public string? BankAccountType { get; set; } // Type of bank account (e.g., "Checking", "Savings")

    }
}
