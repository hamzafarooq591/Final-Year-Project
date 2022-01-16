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

    [RoutePrefix("api/Order")]
    public class OrderController : ApiController
    {
        private OrderService _OrderService = new OrderService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{OrderId}")]
        public DataActionResponse DeleteOrder(int OrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OrderService.DeleteOrder(OrderId).CreateDataActionResponseSuccessForDelete("OrderId", OrderId);
        }

        //get
        [HttpGet, Route("{OrderId}")]
        public DataActionResponse Get(int OrderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OrderService.GetOrderByOrderId(OrderId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<OrderViewModel> Get(int size = 10, int page = 1, 
            string CompanyName = "", string BranchName = "", string CustomerName = "", int? OrderStatusId = null,
            int? OrderId = null, DateTime? FromDate = null, DateTime? ToDate = null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._OrderService.GetOrder(size, page, CompanyName, BranchName, 
                CustomerName, OrderStatusId, OrderId, FromDate, ToDate);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(OrderBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _OrderService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._OrderService.CreateOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{OrderId}")]
        public DataActionResponse Put(OrderBindingModel model, int OrderId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _OrderService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._OrderService.UpdateOrder(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

