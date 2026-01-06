using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace WattWise.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Key]
        //public int UserId { get; set; }

        [StringLength(30)]
        public string? FirstName { get; set; } = string.Empty;
        [StringLength(30)]
        public string? LastName { get; set; } = string.Empty;
        public string FullName => $"{FirstName} {LastName}";

        public string? Address { get; set; } = string.Empty;

        public string? City { get; set; } = string.Empty;
        public string? State { get; set; } = string.Empty;
        public string? PostCode { get; set; } = string.Empty;

        [MaxLength(30)]
        public string? Country { get; set; } = string.Empty;

        public bool IsActive { get; set; } = true; // Indicates if the user is active or inactive

        [Required]
        public required string Role { get; set; } // Tenant, Landlord, Admin, etc.

        public List<String> Permissions { get; set; } = new List<string>(); // List of permissions associated with the user

        public required ICollection<Meter> Meters { get; set; } // List of meters associated with the user

        //public static implicit operator ApplicationUser(int v)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
