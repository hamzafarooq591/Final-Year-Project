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

    [RoutePrefix("api/PerformaInvoice")]
    public class PerformaInvoiceController : ApiController
    {
        private PerformaInvoiceService _PerformaInvoiceService = new PerformaInvoiceService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PerformaInvoiceId}")]
        public DataActionResponse DeletePerformaInvoice(int PerformaInvoiceId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PerformaInvoiceService.DeletePerformaInvoice(PerformaInvoiceId).CreateDataActionResponseSuccessForDelete("PerformaInvoiceId", PerformaInvoiceId);
        }

        //get
        [HttpGet, Route("{PerformaInvoiceId}")]
        public DataActionResponse Get(int PerformaInvoiceId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PerformaInvoiceService.GetPerformaInvoiceByPerformaInvoiceId(PerformaInvoiceId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<PerformaInvoiceViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PerformaInvoiceService.GetPerformaInvoice(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PerformaInvoiceBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PerformaInvoiceService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PerformaInvoiceService.CreatePerformaInvoice(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PerformaInvoiceId}")]
        public DataActionResponse Put(PerformaInvoiceBindingModel model, int PerformaInvoiceId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PerformaInvoiceService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PerformaInvoiceService.UpdatePerformaInvoice(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

