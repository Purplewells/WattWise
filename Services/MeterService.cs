using System;
using System.Collections.Generic;
using System.Linq;
using WattWise.Models;

namespace WattWise.Services
{
    public class MeterService
    {
        private readonly List<Meter> _meters; // Simulated data source for meters
        private readonly List<MeterReading> _meterReadings; // Simulated data source for meter readings

        public MeterService()
        {
            _meters = new List<Meter>(); // Replace with actual database or repository
            _meterReadings = new List<MeterReading>(); // Replace with actual database or repository
        }

        /// <summary>
        /// Updates the balance of a meter asynchronously.
        /// </summary>
        /// <param name="meterSerial">The serial number of the meter.</param>
        /// <param name="amount">The amount to add to the balance.</param>
        public async Task UpdateMeterBalanceAsync(string meterSerial, decimal amount)
        {
            var meter = _meters.FirstOrDefault(m => m.SerialNumber == meterSerial);
            if (meter == null)
            {
                throw new ArgumentException("Meter not found.");
            }

            meter.CurrentBalance += amount;

            if (meter.CurrentBalance < 0)
            {
                throw new InvalidOperationException("Meter balance cannot be negative.");
            }

            await Task.CompletedTask; // Simulate async operation
        }

        /// <summary>
        /// Generates a top-up token for a meter asynchronously.
        /// </summary>
        /// <param name="meterSerial">The serial number of the meter.</param>
        /// <param name="amount">The amount of credit to associate with the token.</param>
        /// <returns>The generated token as a string.</returns>
        public async Task<string> GenerateTopUpTokenAsync(string meterSerial, decimal amount)
        {
            var meter = _meters.FirstOrDefault(m => m.SerialNumber == meterSerial);
            if (meter == null)
            {
                throw new ArgumentException("Meter not found.");
            }

            if (amount <= 0)
            {
                throw new ArgumentException("Amount must be greater than zero.");
            }

            // Generate a unique token
            string token = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 16).ToUpper();

            // Simulate saving the token to a database
            Console.WriteLine($"Generated token for Meter {meter.SerialNumber}: {token} (Amount: {amount})");

            return await Task.FromResult(token);
        }

        /// <summary>
        /// Logs meter usage asynchronously.
        /// </summary>
        /// <param name="meterSerial">The serial number of the meter.</param>
        /// <param name="consumption">The consumption to log.</param>
        public async Task LogMeterUsageAsync(string meterSerial, decimal consumption)
        {
            var meter = _meters.FirstOrDefault(m => m.SerialNumber == meterSerial);
            if (meter == null)
            {
                throw new ArgumentException("Meter not found.");
            }

            if (consumption <= 0)
            {
                throw new ArgumentException("Consumption must be greater than zero.");
            }

            var meterReading = new MeterReading
            {
                MeterId = meter.MeterId,
                Meter = meter,
                CurrentReading = (int)(meter.CurrentReading + consumption),
                PreviousReading = meter.CurrentReading,
                ReadingDate = DateTime.Now,
                LoggedDate = DateTime.Now
            };

            _meterReadings.Add(meterReading);
            meter.CurrentReading = meterReading.CurrentReading;

            await Task.CompletedTask; // Simulate async operation
        }

        /// <summary>
        /// Checks for meters with low credit asynchronously.
        /// </summary>
        /// <returns>A list of meters with low credit.</returns>
        public async Task<List<Meter>> CheckForLowCredit()
        {
            var lowCreditMeters = _meters.Where(m => m.CurrentBalance < 10).ToList(); // Threshold: 10 units
            return await Task.FromResult(lowCreditMeters);
        }

        /// <summary>
        /// Sends low credit alerts asynchronously.
        /// </summary>
        public async Task SendLowCreditAlert()
        {
            var lowCreditMeters = await CheckForLowCredit();

            foreach (var meter in lowCreditMeters)
            {
                // Simulate sending an alert
                Console.WriteLine($"Low credit alert sent for Meter {meter.SerialNumber}. Current balance: {meter.CurrentBalance}");
            }

            await Task.CompletedTask; // Simulate async operation
        }

        /// <summary>
        /// Configures a meter with new settings asynchronously.
        /// </summary>
        /// <param name="meterSerial">The serial number of the meter.</param>
        /// <param name="creditLimit">The new credit limit for the meter.</param>
        /// <param name="tariff">The new tariff for the meter.</param>
        public async Task ConfigureMeterAsync(string meterSerial, decimal creditLimit, string tariff)
        {
            var meter = _meters.FirstOrDefault(m => m.SerialNumber == meterSerial);
            if (meter == null)
            {
                throw new ArgumentException("Meter not found.");
            }

            if (creditLimit <= 0)
            {
                throw new ArgumentException("Credit limit must be greater than zero.");
            }

            if (string.IsNullOrWhiteSpace(tariff))
            {
                throw new ArgumentException("Tariff cannot be null or empty.");
            }

            meter.CreditLimit = creditLimit;
            meter.TarriffRate = decimal.Parse(tariff);

            Console.WriteLine($"Meter {meter.SerialNumber} configured with credit limit {creditLimit} and tariff {tariff}.");

            await Task.CompletedTask; // Simulate async operation
        }



        /// <summary>
        /// Retrieves the configuration details of a meter asynchronously.
        /// </summary>
        /// <param name="meterSerial">The serial number of the meter.</param>
        /// <returns>The meter configuration details.</returns>
        public async Task<Meter> GetMeterConfigurationAsync(string meterSerial)
        {
            // Validate the input
            if (string.IsNullOrWhiteSpace(meterSerial))
            {
                throw new ArgumentException("Meter serial number cannot be null or empty.", nameof(meterSerial));
            }

            // Find the meter by its serial number
            var meter = _meters.FirstOrDefault(m => m.SerialNumber == meterSerial);
            if (meter == null)
            {
                throw new ArgumentException("Meter not found.");
            }

            // Simulate async operation
            return await Task.FromResult(meter);
        }


        /// <summary>
        /// Calculates the consumption based on the current and previous readings.
        /// </summary>
        /// <param name="currentReading">The current reading of the meter.</param>
        /// <param name="previousReading">The previous reading of the meter.</param>
        /// <returns>The calculated consumption in kWh. Throws an exception if the readings are invalid.</returns>
        public int CalculateConsumption(int currentReading, int previousReading)
        {
            // Validation: Ensure readings are non-negative
            if (currentReading < 0 || previousReading < 0)
            {
                throw new ArgumentException("Readings cannot be negative.");
            }

            // Validation: Ensure current reading is not less than previous reading
            if (currentReading < previousReading)
            {
                throw new ArgumentException("Current reading cannot be less than previous reading.");
            }

            // Calculate consumption
            return currentReading - previousReading;
        }

        /// <summary>
        /// Calculates the latest consumption for a given meter based on its readings.
        /// </summary>
        /// <param name="meterReadings">The list of meter readings for the meter.</param>
        /// <returns>The latest consumption in kWh. Throws an exception if readings are invalid or insufficient.</returns>
        public int CalculateLatestConsumption(List<MeterReading> meterReadings)
        {
            if (meterReadings == null || meterReadings.Count < 2)
            {
                throw new ArgumentException("At least two readings are required to calculate the latest consumption.");
            }

            // Sort readings by ReadingDate in descending order
            var sortedReadings = meterReadings.OrderByDescending(r => r.ReadingDate).ToList();

            // Get the latest and second latest readings
            var latestReading = sortedReadings[0];
            var previousReading = sortedReadings[1];

            return CalculateConsumption(latestReading.CurrentReading, previousReading.CurrentReading);
        }

        /// <summary>
        /// Calculates the average consumption for a given meter and updates the Meter class.
        /// </summary>
        /// <param name="meter">The meter object to update.</param>
        /// <param name="meterReadings">The list of meter readings for the meter.</param>
        public void UpdateAverageConsumption(Meter meter, List<MeterReading> meterReadings)
        {
            if (meter == null)
            {
                throw new ArgumentNullException(nameof(meter), "Meter cannot be null.");
            }

            if (meterReadings == null || meterReadings.Count < 2)
            {
                throw new ArgumentException("At least two readings are required to calculate the average consumption.");
            }

            // Calculate total consumption
            int totalConsumption = 0;
            for (int i = 1; i < meterReadings.Count; i++)
            {
                var currentReading = meterReadings[i];
                var previousReading = meterReadings[i - 1];

                totalConsumption += CalculateConsumption(currentReading.CurrentReading, previousReading.CurrentReading);
            }

            // Calculate average consumption
            int averageConsumption = totalConsumption / (meterReadings.Count - 1);

            // Update the Meter class with the average consumption
            meter.Description = $"Average Consumption: {averageConsumption} kWh";
        }
    }
}