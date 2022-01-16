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

    [RoutePrefix("api/CourierCompany")]
    public class CourierCompanyController : ApiController
    {
        private CourierCompanyService _CourierCompanyService = new CourierCompanyService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{CourierCompanyId}")]
        public DataActionResponse DeleteCourierCompany(int CourierCompanyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._CourierCompanyService.DeleteCourierCompany(CourierCompanyId).CreateDataActionResponseSuccessForDelete("CourierCompanyId", CourierCompanyId);
        }

        //get
        [HttpGet, Route("{CourierCompanyId}")]
        public DataActionResponse Get(int CourierCompanyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CourierCompanyService.GetCourierCompanyByCourierCompanyId(CourierCompanyId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<CourierCompanyViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CourierCompanyService.GetCourierCompany(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(CourierCompanyBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _CourierCompanyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._CourierCompanyService.CreateCourierCompany(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{CourierCompanyId}")]
        public DataActionResponse Put(CourierCompanyBindingModel model, int CourierCompanyId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _CourierCompanyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._CourierCompanyService.UpdateCourierCompany(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

