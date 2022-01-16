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

    [RoutePrefix("api/MoneyChanger")]
    public class MoneyChangerController : ApiController
    {
        private MoneyChangerService _MoneyChangerService = new MoneyChangerService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{MoneyChangerId}")]
        public DataActionResponse DeleteMoneyChanger(int MoneyChangerId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._MoneyChangerService.DeleteMoneyChanger(MoneyChangerId).CreateDataActionResponseSuccessForDelete("MoneyChangerId", MoneyChangerId);
        }

        //get
        [HttpGet, Route("{MoneyChangerId}")]
        public DataActionResponse Get(int MoneyChangerId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._MoneyChangerService.GetMoneyChangerByMoneyChangerId(MoneyChangerId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<MoneyChangerViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._MoneyChangerService.GetMoneyChanger(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(MoneyChangerBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _MoneyChangerService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._MoneyChangerService.CreateMoneyChanger(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{MoneyChangerId}")]
        public DataActionResponse Put(MoneyChangerBindingModel model, int MoneyChangerId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _MoneyChangerService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._MoneyChangerService.UpdateMoneyChanger(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

