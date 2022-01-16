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

    [RoutePrefix("api/Patient")]
    public class PatientController : ApiController
    {
        private PatientService _PatientService = new PatientService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PatientId}")]
        public DataActionResponse DeletePatient(int PatientId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._PatientService.DeletePatient(PatientId).CreateDataActionResponseSuccessForDelete("PatientId", PatientId);
        }
       
        //get
        [HttpGet, Route("{PatientId}")]
        public DataActionResponse Get(int PatientId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PatientService.GetPatientByPatientId(PatientId).CreateDataActionResponseSuccess();
        }

        //Authenticate
        [HttpGet, Route("Authenticate")]
        public DataActionResponse Authenticate(string PatientPhoneNumber,string Password)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PatientService.Authenticate(PatientPhoneNumber,Password).CreateDataActionResponseSuccess();
        }

        //get all
        [HttpGet, Route("")]
        public NashPagedList<PatientViewModel> Get(int size = 10, int page = 1,int? BranchId=null)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PatientService.GetPatient(size, page, BranchId);
        }
       
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PatientBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PatientService.CreatePatient(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PatientId}")]
        public DataActionResponse Put(PatientBindingModel model, int PatientId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PatientService.UpdatePatient(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("Activate/{PatientId}")]
        public DataActionResponse Activate(bool isActive, int PatientId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PatientService.ActivatePatient(isActive,PatientId).CreateDataActionResponseSuccess();
        }
    }
}

