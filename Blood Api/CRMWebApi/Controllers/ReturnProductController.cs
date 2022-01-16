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

    [RoutePrefix("api/ReturnProduct")]
    public class ReturnProductController : ApiController
    {
        private ReturnProductService _ReturnProductService = new ReturnProductService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{ReturnProductId}")]
        public DataActionResponse DeleteReturnProduct(int ReturnProductId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ReturnProductService.DeleteReturnProduct(ReturnProductId).CreateDataActionResponseSuccessForDelete("ReturnProductId", ReturnProductId);
        }

        //get
        [HttpGet, Route("{ReturnProductId}")]
        public DataActionResponse Get(int ReturnProductId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ReturnProductService.GetReturnProductByReturnProductId(ReturnProductId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<ReturnProductViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ReturnProductService.GetReturnProduct(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(ReturnProductBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ReturnProductService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ReturnProductService.CreateReturnProduct(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{ReturnProductId}")]
        public DataActionResponse Put(ReturnProductBindingModel model, int ReturnProductId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ReturnProductService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ReturnProductService.UpdateReturnProduct(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

