namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
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
        NashWebApi.NashContext db = new NashWebApi.NashContext();
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
        [HttpPost, Route("Post")]
        
        public DataActionResponse Post(BindingModels.BloodLab.AppointmentSlotViewModelts md)
        {
           
            Appointment ap = new Appointment();
            AppointmentTest at = new AppointmentTest();
            var ptid = db.Patients.Where(w => w.Password == md.PatPassword && w.PhoneNumber == md.PatNumber).FirstOrDefault().Id;
            var time = db.AppointmentSlots.Where(w => w.Id.ToString() == md.Slot).FirstOrDefault();
            var datr = DateTime.Parse(md.AppointmentDateTime + " " + time.SlotTime);
            ap.Addres = md.Address;
            ap.AppointmentPatientName = md.AppointmentPatientName;
            ap.AppointmentDateTime = datr;
            ap.PatientGender = md.PatientGender;
            ap.Comment = md.Comment;
            ap.AppointmentStatus = "true";
            ap.City = md.City;
            ap.CreatedByUserId = 1;
            ap.CreatedOn = DateTime.Now;
            ap.IsBookingForMyself = true;
            ap.IsDeleted = false;
            ap.ModifiedByUserId = 1;
            ap.ModifiedOn = DateTime.Now;
            ap.PatientId = ptid;
            ap.TotalAmount = md.Total;
            db.Appointments.Add(ap);
            db.SaveChanges();
            foreach (var item in md.Value)
            {
                at.AppointmentId = ap.Id;
                at.TestId = db.Tests.Where(w => w.Title == item.name && w.Price == item.price).FirstOrDefault().Id;
                at.CreatedByUserId = ptid;
                at.ModifiedByUserId = ptid;
                at.CreatedOn = DateTime.Now;
                at.ModifiedOn = DateTime.Now;
                db.AppointmentTests.Add(at);
                db.SaveChanges();
            }
            return null;
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

