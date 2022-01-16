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

    [RoutePrefix("api/AccountsHead")]
    public class AccountsHeadController : ApiController
    {
        private AccountsHeadService _AccountsHeadService = new AccountsHeadService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{AccountsHeadId}")]
        public DataActionResponse DeleteAccountsHead(int AccountsHeadId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._AccountsHeadService.DeleteAccountsHead(AccountsHeadId).CreateDataActionResponseSuccessForDelete("AccountsHeadId", AccountsHeadId);
        }

        //get
        [HttpGet, Route("{AccountsHeadId}")]
        public DataActionResponse Get(int AccountsHeadId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AccountsHeadService.GetAccountsHeadByAccountsHeadId(AccountsHeadId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AccountsHeadViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AccountsHeadService.GetAccountsHead(size, page, SearchString);
        }
       //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AccountsHeadBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _AccountsHeadService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AccountsHeadService.CreateAccountsHead(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AccountsHeadId}")]
        public DataActionResponse Put(AccountsHeadBindingModel model, int AccountsHeadId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _AccountsHeadService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AccountsHeadService.UpdateAccountsHead(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

