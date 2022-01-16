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

    [RoutePrefix("api/AppointmentSlot")]
    public class AppointmentSlotController : ApiController
    {
        private AppointmentSlotService _AppointmentSlotService = new AppointmentSlotService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{AppointmentSlotId}")]
        public DataActionResponse DeleteAppointmentSlot(int AppointmentSlotId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._AppointmentSlotService.DeleteAppointmentSlot(AppointmentSlotId).CreateDataActionResponseSuccessForDelete("AppointmentSlotId", AppointmentSlotId);
        }
       
        //get
        [HttpGet, Route("{AppointmentSlotId}")]
        public DataActionResponse Get(int AppointmentSlotId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AppointmentSlotService.GetAppointmentSlotByAppointmentSlotId(AppointmentSlotId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AppointmentSlotViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentSlotService.GetAppointmentSlot(size, page, BranchId);
        }
       
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AppointmentSlotBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentSlotService.CreateAppointmentSlot(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AppointmentSlotId}")]
        public DataActionResponse Put(AppointmentSlotBindingModel model, int AppointmentSlotId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentSlotService.UpdateAppointmentSlot(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

