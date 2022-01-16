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

    [RoutePrefix("api/InventoryStock")]
    public class InventoryStockController : ApiController
    {
        private InventoryStockService _InventoryStockService = new InventoryStockService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{InventoryStockId}")]
        public DataActionResponse DeleteInventoryStock(int InventoryStockId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._InventoryStockService.DeleteInventoryStock(InventoryStockId).CreateDataActionResponseSuccessForDelete("InventoryStockId", InventoryStockId);
        }

        //get
        [HttpGet, Route("{InventoryStockId}")]
        public DataActionResponse Get(int InventoryStockId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InventoryStockService.GetInventoryStockByInventoryStockId(InventoryStockId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<InventoryStockViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._InventoryStockService.GetInventoryStock(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(InventoryStockBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InventoryStockService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InventoryStockService.CreateInventoryStock(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{InventoryStockId}")]
        public DataActionResponse Put(InventoryStockBindingModel model, int InventoryStockId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _InventoryStockService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._InventoryStockService.UpdateInventoryStock(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

