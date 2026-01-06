using Microsoft.CodeAnalysis.Differencing;
using System;
using System.Threading.Tasks;
using Twilio.TwiML.Voice;
using WattWise.Models;
using WattWise.Services; // Ensure this namespace is included

namespace WattWise.Services
{
    public class NotificationService
    {
        private readonly EmailService _emailService;
        private readonly SmsService _smsService;

        public NotificationService(EmailService emailService, SmsService smsService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _smsService = smsService ?? throw new ArgumentNullException(nameof(smsService));
        }

        /// <summary>
        /// Sends a meter configuration update notification email to the user.
        /// </summary>
        /// <param name="userEmail">The user's email address.</param>
        /// <param name="configurationDetails">The configuration details to include in the email.</param>
        //public async Task SendMeterConfigurationUpdateNotificationAsync(string userEmail, string configurationDetails)
        //{
        //    if (string.IsNullOrWhiteSpace(userEmail))
        //    {
        //        throw new ArgumentException("User email cannot be null or empty.", nameof(userEmail));
        //    }

        //    if (string.IsNullOrWhiteSpace(configurationDetails))
        //    {
        //        throw new ArgumentException("Configuration details cannot be null or empty.", nameof(configurationDetails));
        //    }

        //    string subject = "Meter Configuration Update";
        //    string body = $"Your meter configuration has been updated. Here are the details:\n\n{configurationDetails}";

        //    await _emailService.SendEmailAsync(userEmail, subject, body);
        //}
    }
}



//Sending email to user@example.com...
//Subject: Payment Confirmation
//Body: Thank you for your payment. Here are the details:
//Amount: $50.00
//Date: 2023 - 10 - 01
//Transaction ID: 123456

//Sending email to user@example.com...
//Subject: Meter Configuration Update
//Body: Your meter configuration has been updated. Here are the details:
//Tariff Rate: $0.15 / kWh
//Credit Limit: $100.00

//Sending SMS to +1234567890...
//Message: Your account balance is low: $5.00.Please top up to avoid service interruption.

//Sending SMS to +1234567890...
//Message: Warning: Your meter's battery level is low: 15%. Please replace or recharge the battery.





