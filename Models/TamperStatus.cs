using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    // Renamed the class to resolve the CS0101 error  
    public class TamperStatus
    {
        [Key]
        public int TamperStatusID { get; set; }
        public string TamperStatusName { get; set; }
        public string? Description { get; set; }

        public ICollection<Meter> Meters { get; set; } = new List<Meter>();

        // Constructor to initialize properties
        public TamperStatus(int tamperStatusID, string tamperStatusName, string? description = null)
        {
            TamperStatusID = tamperStatusID;
            TamperStatusName = tamperStatusName;
            Description = description;
        }

        // Seed data for TamperStatus
        public static List<TamperStatus> GetTamperStatuses()
        {
            return new List<TamperStatus>
          {
              new TamperStatus(1, "Normal", "No tampering detected"),
              new TamperStatus(2, "Tampered", "Tampering detected"),
              new TamperStatus(3, "Unknown", "Tamper status unknown")
          };
        }

        //// Methods
        //// Get Status by ID
        //public static TamperStatus? GetStatusById(int id)
        //{
        //    return GetTamperStatuses().Find(status => status.TamperStatusID == id);
        //}

        //// Check if status exist or is valid
        //public static bool IsValidStatus(int id)
        //{
        //    return GetTamperStatuses().Exists(status => status.TamperStatusID == id);
        //}

        //// Get all statuses
        //public static List<TamperStatus> GetAllStatuses()
        //{
        //    return GetTamperStatuses();
        //}
    }
}
