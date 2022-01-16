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

    [RoutePrefix("api/WarrantyMode")]
    public class WarrantyModeController : ApiController
    {
        private WarrantyModeService _WarrantyModeService = new WarrantyModeService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{WarrantyModeId}")]
        public DataActionResponse DeleteWarrantyMode(int WarrantyModeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyModeService.DeleteWarrantyMode(WarrantyModeId).CreateDataActionResponseSuccessForDelete("WarrantyModeId", WarrantyModeId);
        }

        //get
        [HttpGet, Route("{WarrantyModeId}")]
        public DataActionResponse Get(int WarrantyModeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyModeService.GetWarrantyModeByWarrantyModeId(WarrantyModeId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<WarrantyModeViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyModeService.GetWarrantyMode(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(WarrantyModeBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyModeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyModeService.CreateWarrantyMode(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{WarrantyModeId}")]
        public DataActionResponse Put(WarrantyModeBindingModel model, int WarrantyModeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyModeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyModeService.UpdateWarrantyMode(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

