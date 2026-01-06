using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    /// <summary>
    /// These are more general and informational, such as outage updates 
    /// or aggregated insights provided to utility companies. 
    /// Notifications may not always require immediate action but keep users informed.
    /// </summary>
    public class Notification
    {
        [Key]
        public int NotificationID { get; set; }  // Primary Key

        //public int? UserID { get; set; }          // Optional: Who this notification is for (nullable for system-wide notifications)
        //public ApplicationUser? User { get; set; }          // Navigation property to User (if applicable)

        public int? MeterID { get; set; }          // Optional: Which meter it relates to (if any)
        public Meter? Meter { get; set; }         // Navigation property to Meter (if applicable)

        [MaxLength(100)]
        public string Title { get; set; } = string.Empty;  // Short title

        [MaxLength(500)]
        public string Message { get; set; } = string.Empty; // Full message

        [MaxLength(20)]
        public int? NotificationTypeId { get; set; }  // e.g., Info, Warning, Error, Success
        public NotificationType? NotificationType { get; set; } // Navigation property to NotificationType (if applicable)

        public bool IsRead { get; set; } = false;  // Mark whether the user has seen the notification

        public DateTime NotificationDate { get; set; } = DateTime.UtcNow; // When notification was created
    }
}
