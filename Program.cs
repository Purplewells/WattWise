using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WattWise.Data;
using WattWise.Models;
using WattWise.Services;

namespace WattWise
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.  
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDBContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 5, // Maximum number of retry attempts  
                            maxRetryDelay: TimeSpan.FromSeconds(10), // Maximum delay between retries  
                            errorNumbersToAdd: null // Additional SQL error numbers to consider transient  
                        );
                    }));

            // Add Identity services
            builder.Services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            })
            .AddRoles<IdentityRole>() // Add support for roles
            .AddEntityFrameworkStores<ApplicationDBContext>();


            builder.Services.AddScoped<SmsService>();
            builder.Services.AddScoped<StripePaymentService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.  
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();

            app.Run();
        }
    }
}
