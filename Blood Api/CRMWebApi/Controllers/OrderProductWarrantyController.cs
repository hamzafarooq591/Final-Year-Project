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

    [RoutePrefix("api/OrderProductWarranty")]
    public class OrderProductWarrantyController : ApiController
    {
        private OrderProductWarrantyService _OrderProductWarrantyService = new OrderProductWarrantyService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{OrderProductWarrantyId}")]
        public DataActionResponse DeleteOrderProductWarranty(int OrderProductWarrantyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OrderProductWarrantyService.DeleteOrderProductWarranty(OrderProductWarrantyId).CreateDataActionResponseSuccessForDelete("OrderProductWarrantyId", OrderProductWarrantyId);
        }

        //get
        [HttpGet, Route("{OrderProductWarrantyId}")]
        public DataActionResponse Get(int OrderProductWarrantyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OrderProductWarrantyService.GetOrderProductWarrantyByOrderProductWarrantyId(OrderProductWarrantyId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<OrderProductWarrantyViewModel> Get(int size = 10, int page = 1, string SearchString = "")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OrderProductWarrantyService.GetOrderProductWarranty(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(OrderProductWarrantyBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _OrderProductWarrantyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._OrderProductWarrantyService.CreateOrderProductWarranty(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{OrderProductWarrantyId}")]
        public DataActionResponse Put(OrderProductWarrantyBindingModel model, int OrderProductWarrantyId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _OrderProductWarrantyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._OrderProductWarrantyService.UpdateOrderProductWarranty(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

