using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WattWise.Models;

namespace WattWise.Data
{
    public class ApplicationDBContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<Meter> Meter { get; set; }
        public DbSet<Transaction> Transaction { get; set; }
        public DbSet<MeterReading> MeterReading { get; set; }
        public DbSet<SmsLog> SmsLog { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Alert> Alert { get; set; }
        public DbSet<TamperStatus> TamperStatus { get; set; }
        public DbSet<CommunicationProtocol> CommunicationProtocol { get; set; }
        public DbSet<MeterType> MeterType { get; set; }
        public DbSet<MeterStatus> MeterStatus { get; set; }
        public DbSet<TopUpToken> TopUpToken { get; set; }
        public DbSet<MeterUsageType> MeterUsageType { get; set; }
        public DbSet<MeterUsageStatus> MeterUsageStatus { get; set; }
        public DbSet<Notification> Notification { get; set; }
        public DbSet<NotificationType> NotificationType { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

       
        }
    }
}
