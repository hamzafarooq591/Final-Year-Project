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

    [RoutePrefix("api/AppointmentOffer")]
    public class AppointmentOfferController : ApiController
    {
        private AppointmentOfferService _AppointmentOfferService = new AppointmentOfferService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;
        [HttpPost, Route("Delete/{AppointmentOfferId}")]
        public DataActionResponse DeleteAppointmentOffer(int AppointmentOfferId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._AppointmentOfferService.DeleteAppointmentOffer(AppointmentOfferId).CreateDataActionResponseSuccessForDelete("AppointmentOfferId", AppointmentOfferId);
        }
       
        //get
        [HttpGet, Route("{AppointmentOfferId}")]
        public DataActionResponse Get(int AppointmentOfferId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AppointmentOfferService.GetAppointmentOfferByAppointmentOfferId(AppointmentOfferId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AppointmentOfferViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentOfferService.GetAppointmentOffer(size, page, BranchId);
        }
       
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AppointmentOfferBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentOfferService.CreateAppointmentOffer(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AppointmentOfferId}")]
        public DataActionResponse Put(AppointmentOfferBindingModel model, int AppointmentOfferId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AppointmentOfferService.UpdateAppointmentOffer(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

