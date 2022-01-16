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

    [RoutePrefix("api/AdvanceSalary")]
    public class AdvanceSalaryController : ApiController
    {
        private AdvanceSalaryService _AdvanceSalaryService = new AdvanceSalaryService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{AdvanceSalaryId}")]
        public DataActionResponse DeleteAdvanceSalary(int AdvanceSalaryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AdvanceSalaryService.DeleteAdvanceSalary(AdvanceSalaryId).CreateDataActionResponseSuccessForDelete("AdvanceSalaryId", AdvanceSalaryId);
        }

        //get
        [HttpGet, Route("{AdvanceSalaryId}")]
        public DataActionResponse Get(int AdvanceSalaryId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AdvanceSalaryService.GetAdvanceSalaryByAdvanceSalaryId(AdvanceSalaryId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<AdvanceSalaryViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._AdvanceSalaryService.GetAdvanceSalary(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(AdvanceSalaryBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _AdvanceSalaryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AdvanceSalaryService.CreateAdvanceSalary(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{AdvanceSalaryId}")]
        public DataActionResponse Put(AdvanceSalaryBindingModel model, int AdvanceSalaryId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _AdvanceSalaryService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._AdvanceSalaryService.UpdateAdvanceSalary(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

