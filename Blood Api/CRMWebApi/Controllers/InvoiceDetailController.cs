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

    [RoutePrefix("api/InvoiceDetail")]
    public class InvoiceDetailController : ApiController
    {
        private InvoiceDetailService _InvoiceDetailService = new InvoiceDetailService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{InvoiceDetailId}")]
        public DataActionResponse DeleteInvoiceDetail(int InvoiceDetailId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceDetailService.DeleteInvoiceDetail(InvoiceDetailId).CreateDataActionResponseSuccessForDelete("InvoiceDetailId", InvoiceDetailId);
        }

        //get
        [HttpGet, Route("{InvoiceDetailId}")]
        public DataActionResponse Get(int InvoiceDetailId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceDetailService.GetInvoiceDetailByInvoiceDetailId(InvoiceDetailId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<InvoiceDetailViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceDetailService.GetInvoiceDetail(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(InvoiceDetailBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InvoiceDetailService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InvoiceDetailService.CreateInvoiceDetail(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{InvoiceDetailId}")]
        public DataActionResponse Put(InvoiceDetailBindingModel model, int InvoiceDetailId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InvoiceDetailService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InvoiceDetailService.UpdateInvoiceDetail(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

