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

    [RoutePrefix("api/WarrantyOrRepairRequest")]
    public class WarrantyOrRepairRequestController : ApiController
    {
        private WarrantyOrRepairRequestService _WarrantyOrRepairRequestService = new WarrantyOrRepairRequestService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{WarrantyOrRepairRequestId}")]
        public DataActionResponse DeleteWarrantyOrRepairRequest(int WarrantyOrRepairRequestId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyOrRepairRequestService.DeleteWarrantyOrRepairRequest(WarrantyOrRepairRequestId).CreateDataActionResponseSuccessForDelete("WarrantyOrRepairRequestId", WarrantyOrRepairRequestId);
        }

        //get
        [HttpGet, Route("{WarrantyOrRepairRequestId}")]
        public DataActionResponse Get(int WarrantyOrRepairRequestId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyOrRepairRequestService.GetWarrantyOrRepairRequestByWarrantyOrRepairRequestId(WarrantyOrRepairRequestId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<WarrantyOrRepairRequestViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyOrRepairRequestService.GetWarrantyOrRepairRequest(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(WarrantyOrRepairRequestBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyOrRepairRequestService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyOrRepairRequestService.CreateWarrantyOrRepairRequest(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{WarrantyOrRepairRequestId}")]
        public DataActionResponse Put(WarrantyOrRepairRequestBindingModel model, int WarrantyOrRepairRequestId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyOrRepairRequestService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyOrRepairRequestService.UpdateWarrantyOrRepairRequest(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

