using System.ComponentModel.DataAnnotations;

public class NotificationType
{
    [Key]
    public int NotificationTypeID { get; set; }

    [Required]
    public string NotificationTypeName { get; set; } = string.Empty;

    [MaxLength(255)]
    public string? Description { get; set; }

    [MaxLength(10)]
    public string? NotificationTypeCode { get; set; }


    // ✅ Optional constructor for convenience
    public NotificationType(string notificationTypeName, string? description = null, string? notificationTypeCode = null)
    {
        NotificationTypeName = notificationTypeName;
        Description = description;
        NotificationTypeCode = notificationTypeCode;
    }

    // ✅ Sample Seed Data
    public static List<NotificationType> GetSampleNotificationTypes()
    {
        return new List<NotificationType>
        {
            new NotificationType(notificationTypeName: "Email", description: "Email notification", notificationTypeCode: "EMAIL"),
            new NotificationType(notificationTypeName: "SMS", description: "SMS notification", notificationTypeCode: "SMS"),
            new NotificationType(notificationTypeName: "Push", description: "Push notification", notificationTypeCode: "PUSH")
        };
    }
}
