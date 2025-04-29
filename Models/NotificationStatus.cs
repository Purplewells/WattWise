using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class NotificationStatus
    {
        // create properties with key
        [Key]
        public int NotificationStatusId { get; set; }
        public required string StatusName { get; set; }
        [MaxLength(50)]
        public string? Description { get; set; }
        [MaxLength(10)]
        public required string StatusCode{ get; set; }

    }
}
