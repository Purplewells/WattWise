using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class NotificationRecipient
    {
        [Key]
        public int NotificationRecipientId { get; set; }  // Primary Key

        // create a reference to the User
        
        public string? UserId { get; set; } // Foreign key to ApplicationUser
        public ApplicationUser? ApplicationUser { get; set; } // Navigation property to ApplicationUser


        [MaxLength(50)]
        public string? NotificationType { get; set; } // e.g., Email, SMS, Push

        [Required]
        public bool IsRead { get; set; } // Tracks if the notification has been read

        [Required]
        public DateTime CreatedDate { get; set; } // Timestamp when the notification was created
    }
}
