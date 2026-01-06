using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    /// <summary>
    /// Alerts: These are typically associated with proactive warnings 
    /// about critical events, such as low credit alerts or tamper detection.
    /// They are designed to draw immediate attention to specific issues or thresholds.
    /// </summary>
    public class Meter
    {
        [Key]
        public int MeterId { get; set; }

        public required string SerialNumber { get; set; } = "SN123456"; // Unique serial number for the meter

        public string? Description { get; set; } // Description of the meter

        [Required]
        public required string Location { get; set; } = "Warehouse"; // Location of the meter, e.g., "Living Room", "Kitchen", etc.

        // public string Latitude { get; set; } = "0.0"; // Latitude of the meter's location
        // public string Longitude { get; set; } = "0.0"; // Longitude of the meter's location


        // public DateTime InstallationDate { get; set; } = DateTime.Now;
        //  public DateTime LastMaintenanceDate { get; set; } = DateTime.Now;
        //  public int CurrentReading { get; set; } = 0;
        // public int PreviousReading { get; set; } = 0;
        //  public decimal CreditLimit { get; set; } = 0.0m; // Credit limit for the meter, if applicable
        //  public decimal TarriffRate { get; set; } = 0.0m; // Tariff rate for the meter, if applicable
        //  public decimal CurrentBalance { get; set; } = 0.0m; // Current balance of the meter

        [MaxLength(30)]
        public string? Manufacturer { get; set; } // Manufacturer of the meter
        public string? Model { get; set; } // Model of the meter
        [MaxLength(10)]
        public string? FirmwareVersion { get; set; } // Firmware version of the meter

        [MaxLength(10)]
        public string? HardwareVersion { get; set; } // Hardware version of the meter




        //public int UserId { get; set; } // Foreign key to ApplicationUser
        //public ApplicationUser? ApplicationUser { get; set; } // Navigation property to ApplicationUser
        public int TamperStatusID { get; set; } // Foreign key to TamperStatus
        public TamperStatus? TamperStatus { get; set; } // Navigation property to TamperStatus

        //bring in metertypeid
        public int MeterTypeID { get; set; } // Foreign key to MeterType
        public MeterType? MeterType { get; set; } // Navigation property to MeterType

        // bring in the meter status
        public int MeterStatusID { get; set; } // Foreign key to MeterStatus
        public MeterStatus? MeterStatus { get; set; } // Navigation property to MeterStatus

        // public ICollection<Transaction> Transaction { get; set; } = new List<Transaction>();
        // public ICollection<Alert> Alert { get; set; } = new List<Alert>();
        // public ICollection<MeterReading> MeterReading { get; set; } = new List<MeterReading>();

        //public ICollection<MeterUsage> MeterUsages { get; set; } = new List<MeterUsage>();



    }
}
