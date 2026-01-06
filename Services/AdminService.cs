using System;
using System.Collections.Generic;
using System.Linq;
using WattWise.Models;

namespace WattWise.Services
{
    public class AdminService
    {
        private readonly List<ApplicationUser> _users; // Simulated data source for users
        private readonly List<Meter> _meters; // Simulated data source for meters
        private readonly List<Transaction> _transactions; // Simulated data source for transactions
        private readonly List<CreditUpdateLog> _creditUpdateLogs; // Simulated data source for credit update logs

        public AdminService()
        {
            _users = new List<ApplicationUser>(); // Replace with actual database or repository
            _meters = new List<Meter>(); // Replace with actual database or repository
            _transactions = new List<Transaction>(); // Replace with actual database or repository
            _creditUpdateLogs = new List<CreditUpdateLog>(); // Replace with actual database or repository
        }

        /// <summary>
        /// Retrieves all users in the system.
        /// </summary>
        /// <returns>A list of all users.</returns>
        public List<ApplicationUser> GetAllUsers()
        {
            return _users;
        }

        /// <summary>
        /// Retrieves all meters in the system.
        /// </summary>
        /// <returns>A list of all meters.</returns>
        public List<Meter> GetAllMeters()
        {
            return _meters;
        }

        /// <summary>
        /// Retrieves the transaction history for a specific user.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>A list of transactions for the specified user.</returns>
        public List<Transaction> GetTransactionHistoryForUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentException("User ID cannot be null or empty.", nameof(userId));
            }

            var user = _users.FirstOrDefault(u => u.Id == userId);
            if (user == null)
            {
                throw new ArgumentException("User not found.");
            }

            return _transactions.Where(t => t.Meter?.ApplicationUser?.Id == userId).ToList();
        }

        /// <summary>
        /// Retrieves all transactions in the system.
        /// </summary>
        /// <returns>A list of all transactions.</returns>
        public List<Transaction> GetAllTransactions()
        {
            return _transactions;
        }

        /// <summary>
        /// Retrieves all credit update logs in the system.
        /// </summary>
        /// <returns>A list of all credit update logs.</returns>
        public List<CreditUpdateLog> GetAllCreditUpdateLogs()
        {
            return _creditUpdateLogs;
        }
    }

    /// <summary>
    /// Represents a log entry for a credit update.
    /// </summary>
    public class CreditUpdateLog
    {
        public required string MeterSerial { get; set; }
        public decimal Amount { get; set; }
        public DateTime UpdateDate { get; set; }
        public string? UpdatedBy { get; set; } // Admin or system user who performed the update
    }
}



