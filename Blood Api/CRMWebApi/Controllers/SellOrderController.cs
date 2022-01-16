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

    [RoutePrefix("api/SellOrder")]
    public class SellOrderController : ApiController
    {
        private SellOrderService _SellOrderService = new SellOrderService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{SellOrderId}")]
        public DataActionResponse DeleteSellOrder(int SellOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SellOrderService.DeleteSellOrder(SellOrderId).CreateDataActionResponseSuccessForDelete("SellOrderId", SellOrderId);
        }

        //get
        [HttpGet, Route("{SellOrderId}")]
        public DataActionResponse Get(int SellOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SellOrderService.GetSellOrderBySellOrderId(SellOrderId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<SellOrderViewModel> Get(int size = 10, int page = 1, bool? isCompleted = null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SellOrderService.GetSellOrder(size, page,isCompleted);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(SellOrderBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SellOrderService.CreateSellOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{SellOrderId}")]
        public DataActionResponse Put(SellOrderBindingModel model, int SellOrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SellOrderService.UpdateSellOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

