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

    [RoutePrefix("api/EmailAccount")]
    public class EmailAccountController : ApiController
    {
        private EmailAccountService _EmailAccountService = new EmailAccountService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{EmailAccountId}")]
        public DataActionResponse DeleteEmailAccount(int EmailAccountId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._EmailAccountService.DeleteEmailAccount(EmailAccountId).CreateDataActionResponseSuccessForDelete("EmailAccountId", EmailAccountId);
        }

        //get
        [HttpGet, Route("{EmailAccountId}")]
        public DataActionResponse Get(int EmailAccountId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmailAccountService.GetEmailAccountByEmailAccountId(EmailAccountId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<EmailAccountViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmailAccountService.GetEmailAccount(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(EmailAccountBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmailAccountService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmailAccountService.CreateEmailAccount(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{EmailAccountId}")]
        public DataActionResponse Put(EmailAccountBindingModel model, int EmailAccountId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmailAccountService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmailAccountService.UpdateEmailAccount(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

