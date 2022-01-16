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

    [RoutePrefix("api/EmployeeLoan")]
    public class EmployeeLoanController : ApiController
    {
        private EmployeeLoanService _EmployeeLoanService = new EmployeeLoanService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

        

        /// <summary>
        /// EmployeeLoan Controller
        /// </summary>
        /// <param name="EmployeeLoanId"></param>
        /// <returns></returns>
        //delete
        [HttpPost, Route("Delete/{EmployeeLoanId}")]
        public DataActionResponse DeleteEmployeeLoan(int EmployeeLoanId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._EmployeeLoanService.DeleteEmployeeLoan(EmployeeLoanId).CreateDataActionResponseSuccessForDelete("EmployeeLoanId", EmployeeLoanId);
        }

        //get
        [HttpGet, Route("{EmployeeLoanId}")]
        public DataActionResponse Get(int EmployeeLoanId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmployeeLoanService.GetEmployeeLoanByEmployeeLoanId(EmployeeLoanId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<EmployeeLoanViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmployeeLoanService.GetEmployeeLoan(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(EmployeeLoanBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmployeeLoanService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmployeeLoanService.CreateEmployeeLoan(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{EmployeeLoanId}")]
        public DataActionResponse Put(EmployeeLoanBindingModel model, int EmployeeLoanId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmployeeLoanService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmployeeLoanService.UpdateEmployeeLoan(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

