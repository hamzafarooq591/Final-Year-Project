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

    [RoutePrefix("api/ProductWarranty")]
    public class ProductWarrantyController : ApiController
    {
        private ProductWarrantyService _ProductWarrantyService = new ProductWarrantyService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{ProductWarrantyId}")]
        public DataActionResponse DeleteProductWarranty(int ProductWarrantyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._ProductWarrantyService.DeleteProductWarranty(ProductWarrantyId).CreateDataActionResponseSuccessForDelete("ProductWarrantyId", ProductWarrantyId);
        }

        //get
        [HttpGet, Route("{ProductWarrantyId}")]
        public DataActionResponse Get(int ProductWarrantyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductWarrantyService.GetProductWarrantyByProductWarrantyId(ProductWarrantyId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<ProductWarrantyViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ProductWarrantyService.GetProductWarranty(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(ProductWarrantyBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ProductWarrantyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ProductWarrantyService.CreateProductWarranty(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{ProductWarrantyId}")]
        public DataActionResponse Put(ProductWarrantyBindingModel model, int ProductWarrantyId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ProductWarrantyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ProductWarrantyService.UpdateProductWarranty(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

