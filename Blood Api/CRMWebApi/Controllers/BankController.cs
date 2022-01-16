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

    [RoutePrefix("api/Bank")]
    public class BankController : ApiController
    {
        private BankService _BankService = new BankService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{BankId}")]
        public DataActionResponse DeleteBank(int BankId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._BankService.DeleteBank(BankId).CreateDataActionResponseSuccessForDelete("BankId", BankId);
        }

        //get
        [HttpGet, Route("{BankId}")]
        public DataActionResponse Get(int BankId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BankService.GetBankByBankId(BankId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<BankViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._BankService.GetBank(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(BankBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BankService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BankService.CreateBank(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{BankId}")]
        public DataActionResponse Put(BankBindingModel model, int BankId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _BankService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._BankService.UpdateBank(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

