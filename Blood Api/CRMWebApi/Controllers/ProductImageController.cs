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

    [RoutePrefix("api/ProductImage")]
    public class ProductImageController : ApiController
    {
        private ProductImageService _ProductImageService = new ProductImageService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{ProductImageId}")]
        public DataActionResponse DeleteProductImage(int ProductImageId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductImageService.DeleteProductImage(ProductImageId).CreateDataActionResponseSuccessForDelete("ProductImageId", ProductImageId);
        }

        //get
        [HttpGet, Route("{ProductImageId}")]
        public DataActionResponse Get(int ProductImageId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductImageService.GetProductImageByProductImageId(ProductImageId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<ProductImageViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductImageService.GetProductImage(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(ProductImageBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ProductImageService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ProductImageService.CreateProductImage(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{ProductImageId}")]
        public DataActionResponse Put(ProductImageBindingModel model, int ProductImageId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ProductImageService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ProductImageService.UpdateProductImage(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

