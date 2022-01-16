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

    [RoutePrefix("api/CompanySetting")]
    public class CompanySettingController : ApiController
    {
        private CompanySettingService _CompanySettingService = new CompanySettingService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{CompanySettingId}")]
        public DataActionResponse DeleteCompanySetting(int CompanySettingId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CompanySettingService.DeleteCompanySetting(CompanySettingId).CreateDataActionResponseSuccessForDelete("CompanySettingId", CompanySettingId);
        }

        //get
        [HttpGet, Route("{CompanySettingId}")]
        public DataActionResponse Get(int CompanySettingId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CompanySettingService.GetCompanySettingByCompanySettingId(CompanySettingId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<CompanySettingViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CompanySettingService.GetCompanySetting(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(CompanySettingBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CompanySettingService.CreateCompanySetting(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{CompanySettingId}")]
        public DataActionResponse Put(CompanySettingBindingModel model, int CompanySettingId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._CompanySettingService.UpdateCompanySetting(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

