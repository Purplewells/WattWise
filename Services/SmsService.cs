using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

public class SmsService
{
    public static async Task SendSmsAsync(string toPhoneNumber, string message)
    {
        // Twilio credentials  
        const string accountSid = "your_account_sid";
        const string authToken = "your_auth_token";

        TwilioClient.Init(accountSid, authToken);

        var messageResource = await MessageResource.CreateAsync(
            to: new PhoneNumber(toPhoneNumber),
            from: new PhoneNumber("your_twilio_phone_number"),
            body: message
        );

        Console.WriteLine($"SMS sent to {toPhoneNumber}. SID: {messageResource.Sid}");
    }
}