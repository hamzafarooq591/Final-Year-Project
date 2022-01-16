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

    [RoutePrefix("api/MissingItem")]
    public class MissingItemController : ApiController
    {
        private MissingItemService _MissingItemService = new MissingItemService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{MissingItemId}")]
        public DataActionResponse DeleteMissingItem(int MissingItemId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._MissingItemService.DeleteMissingItem(MissingItemId).CreateDataActionResponseSuccessForDelete("MissingItemId", MissingItemId);
        }

        //get
        [HttpGet, Route("{MissingItemId}")]
        public DataActionResponse Get(int MissingItemId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._MissingItemService.GetMissingItemByMissingItemId(MissingItemId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<MissingItemViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._MissingItemService.GetMissingItem(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(MissingItemBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _MissingItemService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._MissingItemService.CreateMissingItem(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{MissingItemId}")]
        public DataActionResponse Put(MissingItemBindingModel model, int MissingItemId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _MissingItemService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._MissingItemService.UpdateMissingItem(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

