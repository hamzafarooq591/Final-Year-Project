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

    [RoutePrefix("api/EmployeeBonus")]
    public class EmployeeBonusController : ApiController
    {
        private EmployeeBonusService _EmployeeBonusService = new EmployeeBonusService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{EmployeeBonusId}")]
        public DataActionResponse DeleteEmployeeBonus(int EmployeeBonusId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._EmployeeBonusService.DeleteEmployeeBonus(EmployeeBonusId).CreateDataActionResponseSuccessForDelete("EmployeeBonusId", EmployeeBonusId);
        }

        //get
        [HttpGet, Route("{EmployeeBonusId}")]
        public DataActionResponse Get(int EmployeeBonusId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmployeeBonusService.GetEmployeeBonusByEmployeeBonusId(EmployeeBonusId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<EmployeeBonusViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmployeeBonusService.GetEmployeeBonus(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(EmployeeBonusBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmployeeBonusService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmployeeBonusService.CreateEmployeeBonus(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{EmployeeBonusId}")]
        public DataActionResponse Put(EmployeeBonusBindingModel model, int EmployeeBonusId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmployeeBonusService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmployeeBonusService.UpdateEmployeeBonus(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

