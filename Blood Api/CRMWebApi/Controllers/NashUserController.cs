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

    [RoutePrefix("api/NashUser")]
    public class NashUserController : ApiController
    {
        private NashUserService _nashUserService = new NashUserService();
        private NashUserService _NashUserService = new NashUserService();
        private int UserId = 1;
        [HttpPost, Route("Delete/{NasUserId}")]
        public DataActionResponse DeleteNashUser(int nasUserId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._nashUserService.DeleteNashUser(nasUserId).CreateDataActionResponseSuccessForDelete("nashUserId", nasUserId);
        }

        [HttpGet, Route("{nashUserId}")]
        public DataActionResponse Get(int nashUserId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._nashUserService.GetNashUserByNashUserId(nashUserId).CreateDataActionResponseSuccess();
        }

        [HttpGet, Route("")]
        public NashPagedList<NashUserViewModel> Get(int size = 0x3e8, int page = 1, int? nashUserTypeId = new int?(),string SerachString="")
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._nashUserService.GetNashUsers(size, page, nashUserTypeId,SerachString);
        }
        [HttpGet, Route("genderTypes")]
        public DataActionResponse GetGenderTypes()
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._nashUserService.GetGenderTypes().CreateDataActionResponseSuccess();
        }

        [HttpGet, Route("nashRoles")]
        public DataActionResponse GetNashRoles()
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._nashUserService.GetNashRoles().CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("nashRoles")]
        public DataActionResponse SaveNashRoles(NashRolesBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NashUserService.CreateNashRoles(model, this.UserId).CreateDataActionResponseSuccess();
        }
        [HttpPost, Route("nashRoles/{nashRoleId}")]
        public DataActionResponse UpdateNashRoles(NashRolesBindingModel model, int nashRoleId)
        {
            return this._NashUserService.UpdateNashRole(model, this.UserId).CreateDataActionResponseSuccess();
        }
        [HttpPost, Route("nashRoles/Delete/{nashRoleId}")]
        public DataActionResponse DeleteNashRole(int nashRoleId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            //return this._nashUserService.DeleteNashUser(nasUserId).CreateDataActionResponseSuccessForDelete("nashUserId", nasUserId);
            return this._nashUserService.DeleteNashRole(nashRoleId).CreateDataActionResponseSuccessForDelete("nashRoleId", nashRoleId);
        }



        [HttpGet, Route("nashUserType")]
        public DataActionResponse GetNashUserType()
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._nashUserService.GetNashUserTypes().CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("")]
        public DataActionResponse Post(NashUserBindingModel model)
        {

            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._nashUserService.CreateNashUser(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("Register")]
        public DataActionResponse PostNashUserRegistration(NashUserRegistrationBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._nashUserService.RegisterNashUser(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("Put/{nasUserId}")]
        public DataActionResponse Put(NashUserBindingModel model, int nasUserId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return this._nashUserService.UpdateNashUser(model, this.UserId).CreateDataActionResponseSuccess();
        }

       

        #region "NashUserSession"

        [HttpPost, Route("NashUserSession")]
        public DataActionResponse PostNashUserSession(AuthendicateBindingModel model)
        {

            return this._nashUserService.AuthenticateUser(model, this.UserId).CreateDataActionResponseSuccess();
        }


        //[HttpPost, Route("NashUserSession")]
        //public DataActionResponse PostNashUserSession(NashUserSessionBindingModel model) =>
        //   this._nashUserService.CreateNashUserSession(model, this.UserId).CreateDataActionResponseSuccess();

        //[HttpPost, Route("NashUserSession/Delete/{nasUserSessionId}")]
        //public DataActionResponse DeleteNashUserSession(int nasUserSessionId) =>
        //   this._nashUserService.DeleteNashUserSession(nasUserSessionId)
        //    .CreateDataActionResponseSuccessForDelete("nashUserSessionId", nasUserSessionId);

        //[HttpGet, Route("NashUserSession/{nashUserSessionId}")]
        //public DataActionResponse GetNashUserSession(int nashUserSessionId) =>
        //    this._nashUserService.GetNashUserByNashUserId(nashUserSessionId)
        //    .CreateDataActionResponseSuccess();

        //[HttpGet, Route("NashUserSession")]
        //public NashPagedList<NashUserSessionViewModel> GetNashUserSessionByNashUserId
        //    (int size = 10, int page = 1, int? nashUserId = new int?()) =>
        //    this._nashUserService.GetNashUserSessionsByNashUserId(size, page, nashUserId);

        #endregion




    }
}

