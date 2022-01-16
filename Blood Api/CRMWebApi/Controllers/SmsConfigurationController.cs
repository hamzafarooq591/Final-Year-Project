namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.ViewModels;
    using System;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/SmsConfiguration")]
    public class SmsConfigurationController : ApiController
    {
        private SmsConfigurationService _SmsConfigurationService = new SmsConfigurationService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{SmsConfigurationId}")]
        public DataActionResponse DeleteSmsConfiguration(int SmsConfigurationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SmsConfigurationService.DeleteSmsConfiguration(SmsConfigurationId).CreateDataActionResponseSuccessForDelete("SmsConfigurationId", SmsConfigurationId);
        }

        //get
        [HttpGet, Route("{SmsConfigurationId}")]
        public DataActionResponse Get(int SmsConfigurationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SmsConfigurationService.GetSmsConfigurationBySmsConfigurationId(SmsConfigurationId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<SmsConfigurationViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SmsConfigurationService.GetSmsConfiguration(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(SmsConfigurationBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _SmsConfigurationService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._SmsConfigurationService.CreateSmsConfiguration(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{SmsConfigurationId}")]
        public DataActionResponse Put(SmsConfigurationBindingModel model, int SmsConfigurationId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _SmsConfigurationService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._SmsConfigurationService.UpdateSmsConfiguration(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

