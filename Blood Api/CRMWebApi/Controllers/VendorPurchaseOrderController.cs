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

    [RoutePrefix("api/VendorPurchaseOrder")]
    public class VendorPurchaseOrderController : ApiController
    {
        private VendorPurchaseOrderService _VendorPurchaseOrderService = new VendorPurchaseOrderService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{VendorPurchaseOrderId}")]
        public DataActionResponse DeleteVendorPurchaseOrder(int VendorPurchaseOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._VendorPurchaseOrderService.DeleteVendorPurchaseOrder(VendorPurchaseOrderId).CreateDataActionResponseSuccessForDelete("VendorPurchaseOrderId", VendorPurchaseOrderId);
        }

        //get
        [HttpGet, Route("{VendorPurchaseOrderId}")]
        public DataActionResponse Get(int VendorPurchaseOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._VendorPurchaseOrderService.GetVendorPurchaseOrderByVendorPurchaseOrderId(VendorPurchaseOrderId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<VendorPurchaseOrderViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._VendorPurchaseOrderService.GetVendorPurchaseOrder(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(VendorPurchaseOrderBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _VendorPurchaseOrderService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._VendorPurchaseOrderService.CreateVendorPurchaseOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{VendorPurchaseOrderId}")]
        public DataActionResponse Put(VendorPurchaseOrderBindingModel model, int VendorPurchaseOrderId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _VendorPurchaseOrderService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._VendorPurchaseOrderService.UpdateVendorPurchaseOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

