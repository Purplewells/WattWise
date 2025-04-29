using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace WattWise.Models
{
    public class MeterUsage
    {
        [Key]
        public int MeterUsageId { get; set; }
        public int MeterId { get; set; }
        
        public required Meter Meter { get; set; }

        public DateTime ReadingDate { get; set; } // Date and time of the reading

        public int CurrentReading { get; set; } // Current reading from the meter
        public int PreviousReading { get; set; } // Previous reading from the meter

        public decimal PowerFactor { get; set; } // Power factor of the meter at the time of logging
        public decimal Voltage { get; set; } // Voltage reading from the meter
        public decimal CurrentAmp { get; set; } // Current reading from the meter

        // create a reference to the MeterUsageStatus
        public int MeterUsageStatusId { get; set; } // Foreign key to MeterUsageStatus
        public MeterUsageStatus? MeterUsageStatus { get; set; } // Navigation property to MeterUsageStatus

        // create a reference to MeterUsageType
        public int MeterUsageTypeId { get; set; } // Foreign key to MeterUsageType
        public MeterUsageType? MeterUsageType { get; set; } // Navigation property to MeterUsageType

        public DateTime LoggedDate { get; set; }

        // would be calculated from the current and previous readings in the Reading Service
        //public float Consumption { get; set; } // kWh

        //public float Cost { get; set; }
        // public decimal PeakDemand { get; set; } // Peak demand reading from the meter


    }
}
