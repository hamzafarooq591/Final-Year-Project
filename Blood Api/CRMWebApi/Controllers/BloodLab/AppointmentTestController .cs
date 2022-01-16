namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.Services.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/AppointmentTest")]
    public class AppointmentTestController : ApiController
    {
        private AppointmentTestService _AppointmentTestService = new AppointmentTestService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{AppointmentTestId}")]
        public DataActionResponse DeleteAppointmentTest(int AppointmentTestId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._AppointmentTestService.DeleteAppointmentTest(AppointmentTestId).CreateDataActionResponseSuccessForDelete("AppointmentTestId", AppointmentTestId);
        }

        [HttpGet, Route("GetAppointmentTestByAppointmentId/{AppointmentId}")]
        public List<AppointmentTestViewModel> GetAppointmentTestByAppointmentId(int? AppointmentId = null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentTestService.GetAppointmentTestByAppointmentId(AppointmentId);
        }

        //get
        [HttpGet, Route("{AppointmentTestId}")]
        public DataActionResponse Get(int AppointmentTestId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AppointmentTestService.GetAppointmentTestByAppointmentTestId(AppointmentTestId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AppointmentTestViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentTestService.GetAppointmentTest(size, page, BranchId);
        }
       
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AppointmentTestBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentTestService.CreateAppointmentTest(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AppointmentTestId}")]
        public DataActionResponse Put(AppointmentTestBindingModel model, int AppointmentTestId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentTestService.UpdateAppointmentTest(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

