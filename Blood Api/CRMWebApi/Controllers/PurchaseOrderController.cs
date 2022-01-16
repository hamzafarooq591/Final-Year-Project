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

    [RoutePrefix("api/PurchaseOrder")]
    public class PurchaseOrderController : ApiController
    {
        private PurchaseOrderService _PurchaseOrderService = new PurchaseOrderService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PurchaseOrderId}")]
        public DataActionResponse DeletePurchaseOrder(int PurchaseOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseOrderService.DeletePurchaseOrder(PurchaseOrderId).CreateDataActionResponseSuccessForDelete("PurchaseOrderId", PurchaseOrderId);
        }

        //get
        [HttpGet, Route("{PurchaseOrderId}")]
        public DataActionResponse Get(int PurchaseOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseOrderService.GetPurchaseOrderByPurchaseOrderId(PurchaseOrderId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<PurchaseOrderViewModel> Get(int size = 10, int page = 1,bool? isCompleted = null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseOrderService.GetPurchaseOrder(size, page,isCompleted);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PurchaseOrderBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseOrderService.CreatePurchaseOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PurchaseOrderId}")]
        public DataActionResponse Put(PurchaseOrderBindingModel model, int PurchaseOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseOrderService.UpdatePurchaseOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

