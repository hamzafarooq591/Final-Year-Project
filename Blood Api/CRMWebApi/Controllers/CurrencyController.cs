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

    [RoutePrefix("api/Currency")]
    public class CurrencyController : ApiController
    {
        private CurrencyService _CurrencyService = new CurrencyService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{CurrencyId}")]
        public DataActionResponse DeleteCurrency(int CurrencyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._CurrencyService.DeleteCurrency(CurrencyId).CreateDataActionResponseSuccessForDelete("CurrencyId", CurrencyId);
        }

        //get
        [HttpGet, Route("{CurrencyId}")]
        public DataActionResponse Get(int CurrencyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CurrencyService.GetCurrencyByCurrencyId(CurrencyId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<CurrencyViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CurrencyService.GetCurrency(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(CurrencyBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _CurrencyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._CurrencyService.CreateCurrency(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{CurrencyId}")]
        public DataActionResponse Put(CurrencyBindingModel model, int CurrencyId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _CurrencyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._CurrencyService.UpdateCurrency(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

