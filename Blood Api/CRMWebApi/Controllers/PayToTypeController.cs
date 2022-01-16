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

    [RoutePrefix("api/PayToType")]
    public class PayToTypeController : ApiController
    {
        private PayToTypeService _PayToTypeService = new PayToTypeService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PayToTypeId}")]
        public DataActionResponse DeletePayToType(int PayToTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._PayToTypeService.DeletePayToType(PayToTypeId).CreateDataActionResponseSuccessForDelete("PayToTypeId", PayToTypeId);
        }

        //get
        [HttpGet, Route("{PayToTypeId}")]
        public DataActionResponse Get(int PayToTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PayToTypeService.GetPayToTypeByPayToTypeId(PayToTypeId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<PayToTypeViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PayToTypeService.GetPayToType(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PayToTypeBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PayToTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PayToTypeService.CreatePayToType(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PayToTypeId}")]
        public DataActionResponse Put(PayToTypeBindingModel model, int PayToTypeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PayToTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PayToTypeService.UpdatePayToType(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

