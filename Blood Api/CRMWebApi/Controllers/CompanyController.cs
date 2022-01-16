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

    [RoutePrefix("api/Company")]
    public class CompanyController : ApiController
    {
        private CompanyService _companyService = new CompanyService();
        
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;
//delete
        [HttpPost, Route("Delete/{CompanyId}")]
        public DataActionResponse DeleteCompany(int companyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._companyService.DeleteCompany(companyId).CreateDataActionResponseSuccessForDelete("companyId", companyId);
        }

        //get
        [HttpGet, Route("{companyId}")]
        public DataActionResponse Get(int companyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._companyService.GetCompanyByCompanyId(companyId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<CompanyViewModel> Get(int size = 10, int page = 1,string SearchString ="")
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._companyService.GetCompany(size, page, SearchString);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(CompanyBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _CompanyService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._companyService.CreateCompany(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{companyId}")]
        public DataActionResponse Put(CompanyBindingModel model, int companyId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._companyService.UpdateCompany(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

