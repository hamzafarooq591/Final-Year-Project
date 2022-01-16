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

    [RoutePrefix("api/InventoryRequest")]
    public class InventoryRequestController : ApiController
    {
        private InventoryRequestService _InventoryRequestService = new InventoryRequestService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{InventoryRequestId}")]
        public DataActionResponse DeleteInventoryRequest(int InventoryRequestId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InventoryRequestService.DeleteInventoryRequest(InventoryRequestId).CreateDataActionResponseSuccessForDelete("InventoryRequestId", InventoryRequestId);
        }

        //get
        [HttpGet, Route("{InventoryRequestId}")]
        public DataActionResponse Get(int InventoryRequestId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InventoryRequestService.GetInventoryRequestByInventoryRequestId(InventoryRequestId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<InventoryRequestViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InventoryRequestService.GetInventoryRequest(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(InventoryRequestBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InventoryRequestService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InventoryRequestService.CreateInventoryRequest(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{InventoryRequestId}")]
        public DataActionResponse Put(InventoryRequestBindingModel model, int InventoryRequestId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InventoryRequestService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InventoryRequestService.UpdateInventoryRequest(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

