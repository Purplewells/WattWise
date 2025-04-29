using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class Alert
    {
        // Represents alerts for abnormal readings, tampering or system notificationsetc.
        [Key]
        public int AlertId { get; set; }
        public int MeterId { get; set; }
        public Meter? Meter { get; set; } // Navigation property to Meter

        [MaxLength(20)]
        public required string MeterSerialNumber { get; set; }
        
        [MaxLength(20)]
        public required string AlertType { get; set; }
        
        [MaxLength(50)]
        public string? Message { get; set; }

        public DateTime AlertDate { get; set; } = DateTime.UtcNow;
        public bool IsAcknowledged { get; set; } = false; // Indicates if the alert has been acknowledged by the user

        public DateTime RecordedDate { get; set; }
    }
}