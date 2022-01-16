namespace NashWebApi.Services
{
    using Twilio;
    using Twilio.AspNet;
    using Twilio.Rest.Api.V2010.Account;
    using Twilio.Types;

    public class SmsService 
    {
        public bool SendSms(string ToNumber, string messageBody)
        {
           

            //// Live  
            string accountSid = "ACcc9ed6b0ac4db1564a366a6b5b11db3f";
            string authToken = "83003b19e3c027bbcca42bfa86571c38";

            TwilioClient.Init(accountSid, authToken);

            string fromMobileNumber = "+12246287670";

            var fromPhoneNumber = new PhoneNumber(fromMobileNumber);
            var toPhoneNumber = new PhoneNumber("+92"+ToNumber.Substring(1));

            var message = MessageResource
                .Create(body: messageBody, from: fromPhoneNumber, to: toPhoneNumber);

          

            return true;
        }

       
    }
}

