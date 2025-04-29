using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WattWise.Data;
using WattWise.Models;

namespace WattWise.Services
{
    public class AdminService
    {
        // Handles administrative tasks for managing users, meters, transactions, etc.
        // Methods:

        // GetAllUsers()



        //GetAllMeters()

        //GetTransactionHistoryForUser(string userId)

        //GetAllTransactions()

        //GetAllCreditUpdateLogs()

        private readonly ApplicationDBContext _dbcontext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ILogger<AdminService> _logger;
        public AdminService(UserManager<ApplicationUser> userManager, ILogger<AdminService> logger, ApplicationDBContext dbcontext)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _dbcontext = dbcontext ?? throw new ArgumentNullException(nameof(dbcontext));
        }

        public async Task<List<ApplicationUser>> GetAllUsersAsync()
        {
            try
            {
                return await _userManager.Users.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all users.");
                throw;
            }
        }

        // useful for Admin areas where you want to filter admins, customers, technicians separately
        public async Task<List<ApplicationUser>> GetUsersByRoleAsync(string roleName)
        {
            try
            {
                var usersInRole = await _userManager.GetUsersInRoleAsync(roleName);
                return usersInRole.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error fetching users in role '{roleName}'.");
                throw;
            }
        }


        //public AdminService(ApplicationDBContext context)
        //{
        //    _dbcontext = context;
        //    //_logger = logger;
        //}

        public async Task<List<Meter>> GetAllMeters()
        {
            try
            {
                return await _dbcontext.Meter.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching all meters.");
                throw;
            }
        }

        // write a method to get and filter Active Meters and show which customers owns each Meter
        public async Task<List<Meter>> GetActiveMeters()
        {
            try
            {
                return await _dbcontext.Meter
                    .Where(m => m.MeterStatusID == m.MeterStatusID)
                    .Include(m => m.ApplicationUser) // Assuming Meter has a navigation property to ApplicationUser
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error fetching active meters.");
                throw;
            }
        }
    }
}
