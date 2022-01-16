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

    [RoutePrefix("api/WPQuantity")]
    public class WPQuantityController : ApiController
    {
        private WPQuantityService _WPQuantityService = new WPQuantityService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{WPQuantityId}")]
        public DataActionResponse DeleteWPQuantity(int WPQuantityId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WPQuantityService.DeleteWPQuantity(WPQuantityId).CreateDataActionResponseSuccessForDelete("WPQuantityId", WPQuantityId);
        }

        //get
        [HttpGet, Route("{WPQuantityId}")]
        public DataActionResponse Get(int WPQuantityId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WPQuantityService.GetWPQuantityByWPQuantityId(WPQuantityId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<WPQuantityViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._WPQuantityService.GetWPQuantity(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(WPQuantityBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WPQuantityService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WPQuantityService.CreateWPQuantity(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{WPQuantityId}")]
        public DataActionResponse Put(WPQuantityBindingModel model, int WPQuantityId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _WPQuantityService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._WPQuantityService.UpdateWPQuantity(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

