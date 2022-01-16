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

    [RoutePrefix("api/InvoiceSummary")]
    public class InvoiceSummaryController : ApiController
    {
        private InvoiceSummaryService _InvoiceSummaryService = new InvoiceSummaryService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{InvoiceSummaryId}")]
        public DataActionResponse DeleteInvoiceSummary(int InvoiceSummaryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._InvoiceSummaryService.DeleteInvoiceSummary(InvoiceSummaryId).CreateDataActionResponseSuccessForDelete("InvoiceSummaryId", InvoiceSummaryId);
        }

        //get
        [HttpGet, Route("{InvoiceSummaryId}")]
        public DataActionResponse Get(int InvoiceSummaryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceSummaryService.GetInvoiceSummaryByInvoiceSummaryId(InvoiceSummaryId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<InvoiceSummaryViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InvoiceSummaryService.GetInvoiceSummary(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(InvoiceSummaryBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InvoiceSummaryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InvoiceSummaryService.CreateInvoiceSummary(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{InvoiceSummaryId}")]
        public DataActionResponse Put(InvoiceSummaryBindingModel model, int InvoiceSummaryId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InvoiceSummaryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InvoiceSummaryService.UpdateInvoiceSummary(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

