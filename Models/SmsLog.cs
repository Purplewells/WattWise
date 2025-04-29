using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class SmsLog
    {
        [Key]
        public int SmsLogId { get; set; }

        [MaxLength(20)]
        public required string PhoneNumber { get; set; }

        [MaxLength(160)]
        public string? Message { get; set; }

        public DateTime SentDate { get; set; } = DateTime.UtcNow;
        public bool IsSuccessful { get; set; } = false;
        
        [MaxLength(100)]
        public string? ErrorMessage { get; set; }
    }
}
