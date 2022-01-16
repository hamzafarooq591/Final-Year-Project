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

    [RoutePrefix("api/OtherPayment")]
    public class OtherPaymentController : ApiController
    {
        private OtherPaymentService _OtherPaymentService = new OtherPaymentService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{OtherPaymentId}")]
        public DataActionResponse DeleteOtherPayment(int OtherPaymentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OtherPaymentService.DeleteOtherPayment(OtherPaymentId).CreateDataActionResponseSuccessForDelete("OtherPaymentId", OtherPaymentId);
        }

        //get
        [HttpGet, Route("{OtherPaymentId}")]
        public DataActionResponse Get(int OtherPaymentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OtherPaymentService.GetOtherPaymentByOtherPaymentId(OtherPaymentId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<OtherPaymentViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OtherPaymentService.GetOtherPayment(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(OtherPaymentBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _OtherPaymentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._OtherPaymentService.CreateOtherPayment(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{OtherPaymentId}")]
        public DataActionResponse Put(OtherPaymentBindingModel model, int OtherPaymentId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _OtherPaymentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._OtherPaymentService.UpdateOtherPayment(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

