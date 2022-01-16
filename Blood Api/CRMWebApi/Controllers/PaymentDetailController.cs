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

    [RoutePrefix("api/PaymentDetail")]
    public class PaymentDetailController : ApiController
    {
        private PaymentDetailService _PaymentDetailService = new PaymentDetailService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PaymentDetailId}")]
        public DataActionResponse DeletePaymentDetail(int PaymentDetailId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PaymentDetailService.DeletePaymentDetail(PaymentDetailId).CreateDataActionResponseSuccessForDelete("PaymentDetailId", PaymentDetailId);
        }

        //get
        [HttpGet, Route("{PaymentDetailId}")]
        public DataActionResponse Get(int PaymentDetailId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PaymentDetailService.GetPaymentDetailByPaymentDetailId(PaymentDetailId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<PaymentDetailViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PaymentDetailService.GetPaymentDetail(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PaymentDetailBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PaymentDetailService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PaymentDetailService.CreatePaymentDetail(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PaymentDetailId}")]
        public DataActionResponse Put(PaymentDetailBindingModel model, int PaymentDetailId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PaymentDetailService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PaymentDetailService.UpdatePaymentDetail(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

