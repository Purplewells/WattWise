using System;
using System.Collections.Generic;
using WattWise.Models;

namespace WattWise.CQRS.DTOs
{
    public class MeterDto
    {
        public int MeterId { get; set; }
        public string SerialNumber { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string Location { get; set; } = string.Empty;
        public string Latitude { get; set; } = "0.0";
        public string Longitude { get; set; } = "0.0";
        public DateTime InstallationDate { get; set; }
        public DateTime LastMaintenanceDate { get; set; }
        public int CurrentReading { get; set; }
        public int PreviousReading { get; set; }
        public decimal CreditLimit { get; set; }
        public decimal TarriffRate { get; set; }
        public decimal CurrentBalance { get; set; }
        public string? Manufacturer { get; set; }
        public string? Model { get; set; }
        public string? FirmwareVersion { get; set; }
        public string? HardwareVersion { get; set; }
        public int UserId { get; set; }
        public int TamperStatusID { get; set; }
        public int MeterTypeID { get; set; }
        public int MeterStatusID { get; set; }

        // Display-friendly fields for inventory views
        public string? TamperStatusName { get; set; }
        public string? MeterTypeName { get; set; }
        public string? MeterStatusName { get; set; }
        public string? OwnerName { get; set; }
        public DateTime? LastReadingAt { get; set; }
        public bool IsActive { get; set; }
        public DateTime? LastCommunication { get; set; }
    }
}
