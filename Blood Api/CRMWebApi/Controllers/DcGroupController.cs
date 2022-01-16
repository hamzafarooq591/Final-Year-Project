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

    [RoutePrefix("api/DcGroup")]
    public class DcGroupController : ApiController
    {
        private DcGroupService _DcGroupService = new DcGroupService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{DcGroupId}")]
        public DataActionResponse DeleteDcGroup(int DcGroupId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._DcGroupService.DeleteDcGroup(DcGroupId).CreateDataActionResponseSuccessForDelete("DcGroupId", DcGroupId);
        }

        //get
        [HttpGet, Route("{DcGroupId}")]
        public DataActionResponse Get(int DcGroupId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._DcGroupService.GetDcGroupByDcGroupId(DcGroupId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<DcGroupViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._DcGroupService.GetDcGroup(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(DcGroupBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _DcGroupService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._DcGroupService.CreateDcGroup(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{DcGroupId}")]
        public DataActionResponse Put(DcGroupBindingModel model, int DcGroupId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _DcGroupService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._DcGroupService.UpdateDcGroup(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

