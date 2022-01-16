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

    [RoutePrefix("api/SaleDelivery")]
    public class SaleDeliveryController : ApiController
    {
        private SaleDeliveryService _SaleDeliveryService = new SaleDeliveryService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{SaleDeliveryId}")]
        public DataActionResponse DeleteSaleDelivery(int SaleDeliveryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SaleDeliveryService.DeleteSaleDelivery(SaleDeliveryId).CreateDataActionResponseSuccessForDelete("SaleDeliveryId", SaleDeliveryId);
        }

        //get
        [HttpGet, Route("{SaleDeliveryId}")]
        public DataActionResponse Get(int SaleDeliveryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SaleDeliveryService.GetSaleDeliveryBySaleDeliveryId(SaleDeliveryId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<SaleDeliveryViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SaleDeliveryService.GetSaleDelivery(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(SaleDeliveryBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SaleDeliveryService.CreateSaleDelivery(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{SaleDeliveryId}")]
        public DataActionResponse Put(SaleDeliveryBindingModel model, int SaleDeliveryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SaleDeliveryService.UpdateSaleDelivery(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

