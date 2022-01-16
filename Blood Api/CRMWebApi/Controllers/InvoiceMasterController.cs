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

    [RoutePrefix("api/InvoiceMaster")]
    public class InvoiceMasterController : ApiController
    {
        private InvoiceMasterService _InvoiceMasterService = new InvoiceMasterService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{InvoiceMasterId}")]
        public DataActionResponse DeleteInvoiceMaster(int InvoiceMasterId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceMasterService.DeleteInvoiceMaster(InvoiceMasterId).CreateDataActionResponseSuccessForDelete("InvoiceMasterId", InvoiceMasterId);
        }

        //get
        [HttpGet, Route("{InvoiceMasterId}")]
        public DataActionResponse Get(int InvoiceMasterId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceMasterService.GetInvoiceMasterByInvoiceMasterId(InvoiceMasterId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<InvoiceMasterViewModel> Get(int size = 10, int page = 1, int? BillToType = 0)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceMasterService.GetInvoiceMaster(size, page, BillToType);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(InvoiceMasterBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InvoiceMasterService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InvoiceMasterService.CreateInvoiceMaster(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{InvoiceMasterId}")]
        public DataActionResponse Put(InvoiceMasterBindingModel model, int InvoiceMasterId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InvoiceMasterService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InvoiceMasterService.UpdateInvoiceMaster(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

