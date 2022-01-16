namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.ViewModels;
    using System;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/NashUserRole")]
    public class NashUserRoleController : ApiController
    {
        private NashUserRoleService _NashUserRoleService = new NashUserRoleService();
        private NashUserService _NashUserService = new NashUserService();

        private int UserId = 1;

        [HttpPost, Route("Delete/{NashUserRoleId}")]
        public DataActionResponse DeleteNashUserRole(int NashUserRoleId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashUserRoleService.DeleteNashUserRole(NashUserRoleId).CreateDataActionResponseSuccessForDelete("NashUserRoleId", NashUserRoleId);
        }

        [HttpGet, Route("{NashUserRoleId}")]
        public DataActionResponse GetNashUserRoleByNashUserRoleId(int NashUserRoleId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashUserRoleService.GetNashUserRoleByNashUserRoleId(NashUserRoleId).CreateDataActionResponseSuccess();
        }

        [HttpGet, Route("")]
        public NashPagedList<NashUserRoleViewModel> GetNashUserRoles(int size = 0x3e8, int page = 1)
        {

            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashUserRoleService.GetNashUserRoles(size, page);
        }

        [HttpPost, Route("")]
        public DataActionResponse Post(NashUserRoleBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashUserRoleService.CreateNashUserRole(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("Put/{NashUserRoleId}")]
        public DataActionResponse Put(NashUserRoleBindingModel model, int NashUserRoleId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._NashUserRoleService.UpdateNashUserRole(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }

}

