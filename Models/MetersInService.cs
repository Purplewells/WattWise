// MetersInService are meters that have been assigned to customers and installed at 
// customer locations. Once meter is installed it would have readings and an association with 
// with customer.
// can you create a data model for MetersInService?
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WattWise.Models
{
    public class MetersInService
    {
        [Key]
        public int MeterInServiceId { get; set; }

        [Required]
        public int MeterId { get; set; }

        [ForeignKey("MeterId")]
        public virtual required Meter Meter { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [ForeignKey("CustomerId")]
        public virtual required Customer Customer { get; set; }

        [Required]
        public DateTime InstallationDate { get; set; }

        public DateTime? RemovalDate { get; set; }

        public string? LocationDescription { get; set; }

        public virtual ICollection<MeterReading>? MeterReadings { get; set; }
    }

    public class Customer
    {
    }
}