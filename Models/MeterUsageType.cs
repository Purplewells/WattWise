using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class MeterUsageType
    {
        // Constructor

        // Properties
        [Key]
        public int MeterUsageTypeID { get; set; }
        public required string MeterUsageTypeName { get; set; } // Renamed to avoid conflict with class name  
        public string? Description { get; set; }

        public MeterUsageType()
        {
            // Initialize properties if needed
            // initialize properties
            MeterUsageTypeName = string.Empty;
            Description = string.Empty;

        }
        // Create a sample seed data for the meter usage type from list
        public static List<MeterUsageType> GetSampleMeterUsageTypes()
        {
            return new List<MeterUsageType>
            {
                new MeterUsageType { MeterUsageTypeID = 1, MeterUsageTypeName = "Electricity", Description = "Electricity usage" },
                new MeterUsageType { MeterUsageTypeID = 2, MeterUsageTypeName = "Water", Description = "Water usage" },
                new MeterUsageType { MeterUsageTypeID = 3, MeterUsageTypeName = "Gas", Description = "Gas usage" }
            };
        }
    }
}
