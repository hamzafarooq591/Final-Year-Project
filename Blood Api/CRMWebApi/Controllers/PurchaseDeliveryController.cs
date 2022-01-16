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

    [RoutePrefix("api/PurchaseDelivery")]
    public class PurchaseDeliveryController : ApiController
    {
        private PurchaseDeliveryService _PurchaseDeliveryService = new PurchaseDeliveryService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PurchaseDeliveryId}")]
        public DataActionResponse DeletePurchaseDelivery(int PurchaseDeliveryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseDeliveryService.DeletePurchaseDelivery(PurchaseDeliveryId).CreateDataActionResponseSuccessForDelete("PurchaseDeliveryId", PurchaseDeliveryId);
        }

        //get
        [HttpGet, Route("{PurchaseDeliveryId}")]
        public DataActionResponse Get(int PurchaseDeliveryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseDeliveryService.GetPurchaseDeliveryByPurchaseDeliveryId(PurchaseDeliveryId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<PurchaseDeliveryViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseDeliveryService.GetPurchaseDelivery(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PurchaseDeliveryBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseDeliveryService.CreatePurchaseDelivery(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PurchaseDeliveryId}")]
        public DataActionResponse Put(PurchaseDeliveryBindingModel model, int PurchaseDeliveryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PurchaseDeliveryService.UpdatePurchaseDelivery(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

