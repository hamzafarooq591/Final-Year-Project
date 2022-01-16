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

    [RoutePrefix("api/VendorPODetail")]
    public class VendorPODetailController : ApiController
    {
        private VendorPODetailService _VendorPODetailService = new VendorPODetailService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{VendorPODetailId}")]
        public DataActionResponse DeleteVendorPODetail(int VendorPODetailId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._VendorPODetailService.DeleteVendorPODetail(VendorPODetailId).CreateDataActionResponseSuccessForDelete("VendorPODetailId", VendorPODetailId);
        }

        //get
        [HttpGet, Route("{VendorPODetailId}")]
        public DataActionResponse Get(int VendorPODetailId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._VendorPODetailService.GetVendorPODetailByVendorPODetailId(VendorPODetailId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<VendorPODetailViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._VendorPODetailService.GetVendorPODetail(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(VendorPODetailBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _VendorPODetailService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._VendorPODetailService.CreateVendorPODetail(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{VendorPODetailId}")]
        public DataActionResponse Put(VendorPODetailBindingModel model, int VendorPODetailId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _VendorPODetailService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._VendorPODetailService.UpdateVendorPODetail(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

