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

    [RoutePrefix("api/Warranty")]
    public class WarrantyController : ApiController
    {
        private WarrantyService _WarrantyService = new WarrantyService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{WarrantyId}")]
        public DataActionResponse DeleteWarranty(int WarrantyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._WarrantyService.DeleteWarranty(WarrantyId).CreateDataActionResponseSuccessForDelete("WarrantyId", WarrantyId);
        }

        //get
        [HttpGet, Route("{WarrantyId}")]
        public DataActionResponse Get(int WarrantyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyService.GetWarrantyByWarrantyId(WarrantyId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<WarrantyViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WarrantyService.GetWarranty(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(WarrantyBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyService.CreateWarranty(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{WarrantyId}")]
        public DataActionResponse Put(WarrantyBindingModel model, int WarrantyId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WarrantyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WarrantyService.UpdateWarranty(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

