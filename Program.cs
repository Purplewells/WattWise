using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MediatR;
using WattWise.Data;
using WattWise.Models;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Use InMemory database in Development for quick local runs and visualization.
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
        options.UseInMemoryDatabase("WattWiseInMemory"));
}
else if (!string.IsNullOrWhiteSpace(connectionString))
{
    builder.Services.AddDbContext<ApplicationDBContext>(options =>
        options.UseSqlServer(connectionString));
}
else
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
}

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDBContext>();

builder.Services.AddControllersWithViews();
// Register MediatR handlers in the assembly
builder.Services.AddMediatR(typeof(Program));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapRazorPages()
   .WithStaticAssets();

// Seed some default meters for visualization when DB is empty (development only)
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var db = services.GetRequiredService<ApplicationDBContext>();
        db.Database.EnsureCreated();

        // Only seed sample data when running with the InMemory provider (Development)
        if (db.Database.IsInMemory())
        {
            if (!db.Meter.Any())
            {
                db.Meter.AddRange(
                    new Meter { SerialNumber = "SN-1001", Description = "Demo kitchen meter", Location = "Kitchen", CurrentReading = 120, Transaction = new List<Transaction>(), Alert = new List<Alert>(), MeterReading = new List<MeterReading>() },
                    new Meter { SerialNumber = "SN-1002", Description = "Living room meter", Location = "Living Room", CurrentReading = 450, Transaction = new List<Transaction>(), Alert = new List<Alert>(), MeterReading = new List<MeterReading>() },
                    new Meter { SerialNumber = "SN-1003", Description = "Office meter", Location = "Office", CurrentReading = 780, Transaction = new List<Transaction>(), Alert = new List<Alert>(), MeterReading = new List<MeterReading>() }
                );
                db.SaveChanges();
            }
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred seeding the DB.");
    }
}

app.Run();
