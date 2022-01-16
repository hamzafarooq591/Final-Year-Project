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

    [RoutePrefix("api/WarrantyRequestStatus")]
    public class WarrantyRequestStatusController : ApiController
    {
        private WarrantyRequestStatusService _WarrantyRequestStatusService = new WarrantyRequestStatusService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{WarrantyRequestStatusId}")]
        public DataActionResponse DeleteWarrantyRequestStatus(int WarrantyRequestStatusId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyRequestStatusService.DeleteWarrantyRequestStatus(WarrantyRequestStatusId).CreateDataActionResponseSuccessForDelete("WarrantyRequestStatusId", WarrantyRequestStatusId);
        }

        //get
        [HttpGet, Route("{WarrantyRequestStatusId}")]
        public DataActionResponse Get(int WarrantyRequestStatusId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyRequestStatusService.GetWarrantyRequestStatusByWarrantyRequestStatusId(WarrantyRequestStatusId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<WarrantyRequestStatusViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyRequestStatusService.GetWarrantyRequestStatus(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(WarrantyRequestStatusBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyRequestStatusService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyRequestStatusService.CreateWarrantyRequestStatus(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{WarrantyRequestStatusId}")]
        public DataActionResponse Put(WarrantyRequestStatusBindingModel model, int WarrantyRequestStatusId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyRequestStatusService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyRequestStatusService.UpdateWarrantyRequestStatus(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

