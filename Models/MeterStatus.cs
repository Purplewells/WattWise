using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
namespace WattWise.Models
{
    public class MeterStatus
    {
        [Key]
        public int MeterStatusID { get; set; }
        public required string Status { get; set; }
        public string? Description { get; set; }

        public ICollection<Meter> Meters { get; set; } = new List<Meter>();

    }
}
