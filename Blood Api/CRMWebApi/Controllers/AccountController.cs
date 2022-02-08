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


    [RoutePrefix("api/Account")]
  
    public class AccountController : ApiController
    {
        private AccountService _AccountService = new AccountService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{AccountId}")]
        public DataActionResponse DeleteAccount(int AccountId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._AccountService.DeleteAccount(AccountId).CreateDataActionResponseSuccessForDelete("AccountId", AccountId);
        }
        //getparentAccountIdlist
        [HttpGet, Route("ParentAccountList")]
        public NashPagedList<AccountViewModel> GetParentAccount(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AccountService.GetParentAccount(size, page);
        }

        //get
        [HttpGet, Route("{AccountId}")]
        public DataActionResponse Get(int AccountId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AccountService.GetAccountByAccountId(AccountId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AccountViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AccountService.GetAccount(size, page, BranchId);
        }
        //get trail balance
        [HttpGet, Route("TrailBalance")]
        public NashPagedList<TrailBalanceViewModel> GetTrailBalance(int size = 10, int page = 1, string SearchString = "")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AccountService.GetTrailBalance(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AccountBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _AccountService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AccountService.CreateAccount(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AccountId}")]
        public DataActionResponse Put(AccountBindingModel model, int AccountId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _AccountService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AccountService.UpdateAccount(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

