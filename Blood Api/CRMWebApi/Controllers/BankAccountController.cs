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

    [RoutePrefix("api/BankAccount")]
    public class BankAccountController : ApiController
    {
        private BankAccountService _BankAccountService = new BankAccountService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{BankAccountId}")]
        public DataActionResponse DeleteBankAccount(int BankAccountId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BankAccountService.DeleteBankAccount(BankAccountId).CreateDataActionResponseSuccessForDelete("BankAccountId", BankAccountId);
        }

        //get
        [HttpGet, Route("{BankAccountId}")]
        public DataActionResponse Get(int BankAccountId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BankAccountService.GetBankAccountByBankAccountId(BankAccountId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<BankAccountViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BankAccountService.GetBankAccount(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(BankAccountBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BankAccountService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BankAccountService.CreateBankAccount(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{BankAccountId}")]
        public DataActionResponse Put(BankAccountBindingModel model, int BankAccountId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BankAccountService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BankAccountService.UpdateBankAccount(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

