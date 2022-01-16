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

    [RoutePrefix("api/DcSummary")]
    public class DcSummaryController : ApiController
    {
        private DcSummaryService _DcSummaryService = new DcSummaryService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{DcSummaryId}")]
        public DataActionResponse DeleteDcSummary(int DcSummaryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._DcSummaryService.DeleteDcSummary(DcSummaryId).CreateDataActionResponseSuccessForDelete("DcSummaryId", DcSummaryId);
        }

        //get
        [HttpGet, Route("{DcSummaryId}")]
        public DataActionResponse Get(int DcSummaryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._DcSummaryService.GetDcSummaryByDcSummaryId(DcSummaryId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<DcSummaryViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._DcSummaryService.GetDcSummary(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(DcSummaryBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _DcSummaryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._DcSummaryService.CreateDcSummary(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{DcSummaryId}")]
        public DataActionResponse Put(DcSummaryBindingModel model, int DcSummaryId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _DcSummaryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._DcSummaryService.UpdateDcSummary(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

