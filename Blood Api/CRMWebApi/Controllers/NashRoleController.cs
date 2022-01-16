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

    [RoutePrefix("api/NashRole")]
    public class NashRoleController : ApiController
    {
        private NashRoleService _nashRoleService = new NashRoleService();
        private NashRoleService _NashRoleService = new NashRoleService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;
//delete
        [HttpPost, Route("Delete/{NashRoleId}")]
        public DataActionResponse DeleteNashRole(int nashRoleId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._nashRoleService.DeleteNashRole(nashRoleId).CreateDataActionResponseSuccessForDelete("nashRoleId", nashRoleId);
        }

        //get
        [HttpGet, Route("{nashRoleId}")]
        public DataActionResponse Get(int nashRoleId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._nashRoleService.GetNashRoleByNashRoleId(nashRoleId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<NashRolesViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._nashRoleService.GetNashRole(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(NashRolesBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._nashRoleService.CreateNashRole(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{nasRoleId}")]
        public DataActionResponse Put(NashRolesBindingModel model, int nasRoleId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._nashRoleService.UpdateNashRole(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

