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

    [RoutePrefix("api/Appointment")]
    public class AppointmentController : ApiController
    {
        private AppointmentService _AppointmentService = new AppointmentService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{AppointmentId}")]
        public DataActionResponse DeleteAppointment(int AppointmentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._AppointmentService.DeleteAppointment(AppointmentId).CreateDataActionResponseSuccessForDelete("AppointmentId", AppointmentId);
        }
       
        //get
        [HttpGet, Route("{AppointmentId}")]
        public DataActionResponse Get(int AppointmentId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AppointmentService.GetAppointmentByAppointmentId(AppointmentId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AppointmentViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentService.GetAppointment(size, page, BranchId);
        }

        [HttpGet, Route("GetAppointmentByPatientId/{PatientId}")]
        public List<AppointmentViewModel> GetAppointmentByPatientId(int? PatientId = null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentService.GetAppointmentByPatientId(PatientId);
        }

        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AppointmentBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentService.CreateAppointment(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AppointmentId}")]
        public DataActionResponse Put(AppointmentBindingModel model, int AppointmentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentService.UpdateAppointment(model, this.UserId).CreateDataActionResponseSuccess();
        }


    }
}

