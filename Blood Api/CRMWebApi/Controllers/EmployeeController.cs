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

    [RoutePrefix("api/Employee")]
    public class EmployeeController : ApiController
    {
        private EmployeeService _EmployeeService = new EmployeeService();
        private NashUserService _nashUserService = new NashUserService();
        private DesignationService _DesignationService = new DesignationService();
        private int UserId = 1;

        #region Designation

        //delete
        [HttpPost, Route("Designation/Delete/{DesignationId}")]
        public DataActionResponse DeleteDesignation(int DesignationId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._DesignationService.DeleteDesignation(DesignationId).CreateDataActionResponseSuccessForDelete("DesignationId", DesignationId);
        }

        //get
        [HttpGet, Route("Designation/{DesignationId}")]
        public DataActionResponse GetDesignation(int DesignationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._DesignationService.GetDesignationByDesignationId(DesignationId).CreateDataActionResponseSuccess();
        }
        //getall
        [HttpGet, Route("Designation")]
        public NashPagedList<DesignationViewModel> GetAllDesignation(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._DesignationService.GetDesignation(size, page);
        }
        //save
        [HttpPost, Route("Designation")]
        public DataActionResponse Post(DesignationBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _DesignationService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._DesignationService.CreateDesignation(model, this.UserId).CreateDataActionResponseSuccess();
        }
        //Update
        [HttpPost, Route("Designation/Put/{DesignationId}")]
        public DataActionResponse Put(DesignationBindingModel model, int DesignationId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _DesignationService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._DesignationService.UpdateDesignation(model, this.UserId).CreateDataActionResponseSuccess();
        }
        #endregion

        //delete
        [HttpPost, Route("Delete/{EmployeeId}")]
        public DataActionResponse DeleteEmployee(int EmployeeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmployeeService.DeleteEmployee(EmployeeId).CreateDataActionResponseSuccessForDelete("EmployeeId", EmployeeId);
        }

        //get
        [HttpGet, Route("{EmployeeId}")]
        public DataActionResponse Get(int EmployeeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmployeeService.GetEmployeeByEmployeeId(EmployeeId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<EmployeeViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmployeeService.GetEmployee(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(EmployeeBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmployeeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmployeeService.CreateEmployee(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{EmployeeId}")]
        public DataActionResponse Put(EmployeeBindingModel model, int EmployeeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmployeeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmployeeService.UpdateEmployee(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

