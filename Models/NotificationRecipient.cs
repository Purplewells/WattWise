using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using WattWise.Models;

public class NotificationRecipient
{
    [Key]
    public int NotificationRecipientId { get; set; }  // Primary Key

    // create a reference to the User
    public ApplicationUser? User { get; set; } // Navigation property to ApplicationUser
    public string? UserId { get; set; } // Foreign key to ApplicationUser
    public string? UserName { get; set; } // Username of the recipient

    [MaxLength(50)]
    public string? NotificationType { get; set; } // e.g., Email, SMS, Push

    [Required]
    public bool IsRead { get; set; } // Tracks if the notification has been read

    [Required]
    public DateTime CreatedDate { get; set; } // Timestamp when the notification was created
}
