using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class MeterType
    {
        [Key]
        public int MeterTypeID { get; private set; } // Changed to private set
        public string? MeterTypeName { get; private set; } // Changed to private set
        public string? Description { get; private set; } // Changed to private set
        public ICollection<Meter> Meters { get; set; } = new List<Meter>();


        // Constructor to initialize properties
        public MeterType(string meterTypeName, string description)
        {
            MeterTypeName = meterTypeName;
            Description = description;
        }

        // Create a sample seed data for the meter type from list
        public static List<MeterType> GetSampleMeterTypes()
        {
            return new List<MeterType>
               {
                   new MeterType("Electricity", "Electricity meter"),
                   new MeterType("Water", "Water meter"),
                   new MeterType("Gas", "Gas meter")
               };
            //}
        }
    }
}
