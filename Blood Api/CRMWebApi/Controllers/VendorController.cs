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

    [RoutePrefix("api/Vendor")]
    public class VendorController : ApiController
    {
        private VendorService _VendorService = new VendorService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{VendorId}")]
        public DataActionResponse DeleteVendor(int VendorId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._VendorService.DeleteVendor(VendorId).CreateDataActionResponseSuccessForDelete("VendorId", VendorId);
        }

        //get
        [HttpGet, Route("{VendorId}")]
        public DataActionResponse Get(int VendorId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._VendorService.GetVendorByVendorId(VendorId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<VendorViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._VendorService.GetVendor(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(VendorBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _VendorService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._VendorService.CreateVendor(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{VendorId}")]
        public DataActionResponse Put(VendorBindingModel model, int VendorId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _VendorService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._VendorService.UpdateVendor(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

