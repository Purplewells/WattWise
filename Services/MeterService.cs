using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Security.Cryptography;
using WattWise.Data;
using WattWise.Models;

namespace WattWise.Services
{

    public class MeterService
    {
        private readonly ApplicationDBContext _dbcontext;

        public MeterService(ApplicationDBContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        //private readonly ILogger<MeterService> _logger;

        // ✅ CREATE
        public async Task<Meter> CreateMeterAsync(Meter meter)
        {
            _dbcontext.Meter.Add(meter);
            await _dbcontext.SaveChangesAsync();
            return meter;
        }

        // ✅ READ ALL
        public async Task<List<Meter>> GetAllMeters()
        {
            return await _dbcontext.Meter.ToListAsync();
        }

        // ✅ READ ONE (By ID)
        public async Task<Meter?> GetMeterByIdAsync(int id)
        {
            return await _dbcontext.Meter.FirstOrDefaultAsync(m => m.MeterId == id);
        }

        // ✅ UPDATE
        public async Task<bool> UpdateMeterAsync(Meter meter)
        {
            var existingMeter = await _dbcontext.Meter.FirstOrDefaultAsync(m => m.MeterId == meter.MeterId);
            if (existingMeter == null)
            {
                return false;
            }

            existingMeter.SerialNumber = meter.SerialNumber;
            existingMeter.Model = meter.Model;
            existingMeter.InstallationDate = meter.InstallationDate;
            existingMeter.CurrentBalance = meter.CurrentBalance;
            //existingMeter.MeterStatusID = meter.MeterStatusID;
            // update any other fields as necessary

            await _dbcontext.SaveChangesAsync();
            return true;
        }

        // ✅ DELETE
        public async Task<bool> DeleteMeterAsync(int id)
        {
            var meter = await _dbcontext.Meter.FirstOrDefaultAsync(m => m.MeterId == id);
            if (meter == null)
            {
                return false;
            }

            _dbcontext.Meter.Remove(meter);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

   
        // Method to get all meters  
        public async Task<List<Meter>> GetAllMetersAsync()
        {
            return await _dbcontext.Meter.ToListAsync();
        }

        // Update Meter Balance Async  
        public async Task<bool> UpdateMeterBalanceAsync(int meterId, decimal newBalance)
        {
            var meter = await _dbcontext.Meter.FindAsync(meterId);
            if (meter == null)
            {
                return false; // Meter not found  
            }
            meter.CurrentReading = (int)newBalance; // Explicitly cast decimal to int  
            _dbcontext.Meter.Update(meter);
            await _dbcontext.SaveChangesAsync();
            return true;
        }

        /// <summary>  
        /// Logs the electricity usage for a given meter.  
        /// </summary>  
        /// <param name="meterId">The unique ID of the meter.</param>  
        /// <param name="serialNumber">The serial number of the meter.</param>  
        /// <param name="consumption">The amount of electricity consumed (in kWh).</param>  
        public async Task LogMeterUsageAsync(int meterId, string meterSerialNumber, decimal consumption)
        {
            var meter = await _dbcontext.Meter.FindAsync(meterId);
            if (meter == null)
            {
                throw new ArgumentException("Meter not found.");
            }

            var usage = new MeterUsage
            {
                MeterId = meterId,
                Meter = meter, // Set the required 'Meter' property  
                LoggedDate = DateTime.UtcNow
            };

            // Corrected the property to use the appropriate DbSet<MeterUsage>  
            _dbcontext.MeterUsage.Add(usage);
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<string> GenerateAndSaveTopUpTokenAsync(int meterId, string meterSerialNumber, decimal amount, int customerId)
        {
            // Create a token
            string input = $"{meterSerialNumber}-{amount}-{DateTime.UtcNow.Ticks}";

            using (var sha256 = SHA256.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha256.ComputeHash(inputBytes);
                string token = BitConverter.ToString(hashBytes)
                    .Replace("-", "")
                    .Substring(0, 10)
                    .ToUpper();

                // Save to database
                var topUpToken = new TopUpToken
                {
                    MeterId = meterId,
                    MeterSerialNumber = meterSerialNumber,
                    Amount = amount,
                    Token = token,
                    //Customer = customerId,
                    LoggedDate = DateTime.UtcNow
                };

                _dbcontext.TopUpToken.Add(topUpToken);
                await _dbcontext.SaveChangesAsync();

                return token;
            }
        }

        public async Task CheckForLowCreditAsync(int meterId, string meterSerialNumber, decimal balance)
        {
            const decimal LOW_CREDIT_THRESHOLD = 10.00m; // You can move this to config later

            if (balance < LOW_CREDIT_THRESHOLD)
            {

                //_logger.LogWarning($"Low credit alert for meter {meterSerialNumber}. Current balance: {balance}");

                // Optionally log an alert record into database
                var alert = new Alert
                {
                    MeterId = meterId,
                    MeterSerialNumber = meterSerialNumber,
                    AlertType = "LowCredit",
                    Message = $"Credit balance is low: {balance:C}",
                    RecordedDate = DateTime.UtcNow
                };

                _dbcontext.Alert.Add(alert);
                await _dbcontext.SaveChangesAsync();

                // Optionally trigger SMS/Email notification here in the future
            }
        }

        public async Task ConfigureMeterAsync(int meterId, string meterSerialNumber, decimal creditLimit, decimal tarriffRate)
        {
            // First, locate the meter
            var meter = await _dbcontext.Meter.FirstOrDefaultAsync(m => m.SerialNumber == meterSerialNumber);

            if (meter == null)
            {
                //_logger.LogError($"Meter {meterSerialNumber} not found. Cannot configure.");
                throw new Exception($"Meter {meterSerialNumber} not found.");
            }

            // Update settings
            meter.CreditLimit = creditLimit;
            meter.TarriffRate = tarriffRate;

            _dbcontext.Meter.Update(meter);
            await _dbcontext.SaveChangesAsync();

            //_logger.LogInformation($"Meter {MetererialNumber} successfully configured. CreditLimit: {creditLimit}, Tariff: {tarriffRate}");

            // TODO: Optionally send command to physical meter device if API becomes available
            // Later, when you have the real Emlite API, you would call something like emliteClient.ConfigureMeter(Metererial, creditLimit, tariff) inside this method.
        }

        public async Task SendLowCreditAlertAsync(int meterId, string meterSerialNumber, decimal balance)
        {
            var alert = new Alert
            {
                MeterId = meterId,
                MeterSerialNumber = meterSerialNumber,
                AlertType = "LowCredit",
                Message = $"Credit balance is low: {balance:C}",
                RecordedDate = DateTime.UtcNow
            };

            _dbcontext.Alert.Add(alert);
            await _dbcontext.SaveChangesAsync();

            //_logger.LogWarning($"Low credit alert generated for Meter {meterSerialNumber}: Balance = {balance}");

            // TODO: Add optional SMS / Email notification trigger here later
        }

        public async Task SendLowBatteryAlertAsync(int meterId, string meterSerialNumber, decimal batteryLevel)
        {
            var alert = new Alert
            {
                MeterId = meterId,
                MeterSerialNumber = meterSerialNumber,
                AlertType = "LowBattery",
                Message = $"Battery level is low: {batteryLevel}%",
                RecordedDate = DateTime.UtcNow
            };

            _dbcontext.Alert.Add(alert);
            await _dbcontext.SaveChangesAsync();

            //_logger.LogWarning($"Low battery alert generated for Meter {meterSerialNumber}: Battery Level = {batteryLevel}%");

            // TODO: Optional SMS/Email notification can be added here
        }


      

    
    }

}
