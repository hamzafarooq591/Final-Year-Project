namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.Services.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Linq;
    using System.Net.Http.Headers;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/AppointmentTestResult")]
    public class AppointmentTestResultController : ApiController
    {
        private AppointmentTestResultResultService _AppointmentTestResultService = new AppointmentTestResultResultService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

        //delete
        [HttpPost, Route("Delete/{AppointmentTestResultId}")]
        public DataActionResponse DeleteAppointmentTestResult(int AppointmentTestResultId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._AppointmentTestResultService.DeleteAppointmentTestResult(AppointmentTestResultId).CreateDataActionResponseSuccessForDelete("AppointmentTestResultId", AppointmentTestResultId);
        }

        //get
        [HttpGet, Route("GetAppointmentTestResultByAppointmentId")]
        public DataActionResponse GetByAppointmentId(int AppointmenttId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AppointmentTestResultService.GetAppointmentTestResultByAppointmentId(AppointmenttId).CreateDataActionResponseSuccess();
        }

        //get
        [HttpGet, Route("{AppointmentTestResultId}")]
        public DataActionResponse Get(int AppointmentTestResultId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AppointmentTestResultService.GetAppointmentTestResultByAppointmentTestResultId(AppointmentTestResultId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AppointmentTestResultViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentTestResultService.GetAppointmentTestResult(size, page, BranchId);
        }
       
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AppointmentTestResultBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentTestResultService.CreateAppointmentTestResult(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AppointmentTestResultId}")]
        public DataActionResponse Put(AppointmentTestResultBindingModel model, int AppointmentTestResultId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentTestResultService.UpdateAppointmentTestResult(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

