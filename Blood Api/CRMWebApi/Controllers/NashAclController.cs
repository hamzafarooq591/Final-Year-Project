namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/NashAcl")]
    public class NashAclController : ApiController
    {
        private NashAclService _NashAclService = new NashAclService();
        private NashUserService _NashUserService = new NashUserService();

        private int UserId = 1;

        [HttpPost, Route("Delete/{NashAclId}")]
        public DataActionResponse DeleteNashAcl(int NashAclId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashAclService.DeleteNashAcl(NashAclId).CreateDataActionResponseSuccessForDelete("NashAclId", NashAclId);
        }

        [HttpGet, Route("{NashAclId}")]
        public DataActionResponse GetNashAclByNashAclId(int NashAclId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashAclService.GetNashAclByNashAclId(NashAclId).CreateDataActionResponseSuccess();
        }

        [HttpGet, Route("")]
        public NashPagedList<NashAclViewModel> GetNashAcls(int size = 0x3e8, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashAclService.GetNashAcls(size, page);
        }

        [HttpGet, Route("NashUserAcl/{NashUserId}")]
        public List<NashAclViewModel> GetNashAclByNashUserId(int NashUserId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashAclService.GetNashAclByNashUserId(NashUserId);
        }

        [HttpPost, Route("")]
        public DataActionResponse Post(NashAclBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashAclService.CreateNashAcl(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("Put/{NashAclId}")]
        public DataActionResponse Put(NashAclBindingModel model, int NashAclId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashAclService.UpdateNashAcl(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }

}

