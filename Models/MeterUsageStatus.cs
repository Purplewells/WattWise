using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class MeterUsageStatus
    {
        // create properties for ReadingStatus

        [Key]
        public int MeterUsageStatusId { get; set; }

        [Required]
        [MaxLength(50)]
        public string StatusName { get; set; } = string.Empty; // e.g., "Normal", "Low Credit", "Disconnected"

        [MaxLength(255)]
        public string? Description { get; set; }

        public bool IsActive { get; set; } = true;  // You can deactivate statuses if needed

        // Optional: Timestamp for auditing
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        // create a navigation property to the MeterUsage
        public ICollection<MeterUsage>? MeterUsages { get; set; } // Navigation property to MeterUsage
        // Optional: You can add a foreign key to another table if needed
    }
}