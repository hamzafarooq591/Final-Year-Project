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

    [RoutePrefix("api/ProductInStore")]
    public class ProductInStoreController : ApiController
    {
        private ProductInStoreService _ProductInStoreService = new ProductInStoreService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{ProductInStoreId}")]
        public DataActionResponse DeleteProductInStore(int ProductInStoreId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductInStoreService.DeleteProductInStore(ProductInStoreId).CreateDataActionResponseSuccessForDelete("ProductInStoreId", ProductInStoreId);
        }

        //get
        [HttpGet, Route("{ProductInStoreId}")]
        public DataActionResponse Get(int ProductInStoreId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductInStoreService.GetProductInStoreByProductInStoreId(ProductInStoreId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<ProductInStoreViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductInStoreService.GetProductInStore(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(ProductInStoreBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ProductInStoreService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ProductInStoreService.CreateProductInStore(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{ProductInStoreId}")]
        public DataActionResponse Put(ProductInStoreBindingModel model, int ProductInStoreId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ProductInStoreService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ProductInStoreService.UpdateProductInStore(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

