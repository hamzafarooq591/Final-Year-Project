namespace NashWebApi.Controllers
{
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using System.Web.Http;

    [RoutePrefix("api/Sms")]
    public class SmsController : ApiController
    {
        private SmsService _SmsService = new SmsService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("SendSms")]
        public DataActionResponse SendSms(string ToNumber,string smsText)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._SmsService.SendSms(ToNumber,smsText)
                .CreateDataActionResponseSuccessForDelete("ToNumber", ToNumber);
        }
       
     
      
    }
}

