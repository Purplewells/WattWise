using System;
using System.Collections.Concurrent;
using System.Net.Mail;
using System.Threading.Tasks;

namespace WattWise.Services
{
    public class EmailService
    {
        // A thread-safe dictionary to track the last email sent time for each user
        private readonly ConcurrentDictionary<string, DateTime> _lastEmailSentTime;
        private readonly TimeSpan _emailCooldownPeriod;

        public EmailService()
        {
            _lastEmailSentTime = new ConcurrentDictionary<string, DateTime>();
            _emailCooldownPeriod = TimeSpan.FromMinutes(10); // Cooldown period to prevent frequent emails
        }

        /// <summary>
        /// Sends an email notification to a user.
        /// </summary>
        /// <param name="toEmail">The recipient's email address.</param>
        /// <param name="subject">The subject of the email.</param>
        /// <param name="body">The body of the email.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // Validate email address
            if (string.IsNullOrWhiteSpace(toEmail) || !IsValidEmail(toEmail))
            {
                throw new ArgumentException("Invalid email address.", nameof(toEmail));
            }

            // Validate subject and body
            if (string.IsNullOrWhiteSpace(subject))
            {
                throw new ArgumentException("Email subject cannot be empty.", nameof(subject));
            }

            if (string.IsNullOrWhiteSpace(body))
            {
                throw new ArgumentException("Email body cannot be empty.", nameof(body));
            }

            // Check cooldown period
            if (_lastEmailSentTime.TryGetValue(toEmail, out var lastSentTime))
            {
                if (DateTime.UtcNow - lastSentTime < _emailCooldownPeriod)
                {
                    Console.WriteLine($"Email not sent to {toEmail}. Cooldown period is still active.");
                    return;
                }
            }

            // Simulate sending the email (replace with actual email-sending logic)
            Console.WriteLine($"Sending email to {toEmail}...");
            Console.WriteLine($"Subject: {subject}");
            Console.WriteLine($"Body: {body}");

            // Update the last email sent time
            _lastEmailSentTime[toEmail] = DateTime.UtcNow;

            await Task.CompletedTask; // Simulate async operation
        }

        /// <summary>
        /// Validates an email address.
        /// </summary>
        /// <param name="email">The email address to validate.</param>
        /// <returns>True if the email address is valid; otherwise, false.</returns>
        private bool IsValidEmail(string email)
        {
            try
            {
                var mailAddress = new MailAddress(email);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

