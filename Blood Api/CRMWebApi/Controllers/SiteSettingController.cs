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

    [RoutePrefix("api/SiteSetting")]
    public class SiteSettingController : ApiController
    {
        private SiteSettingService _SiteSettingService = new SiteSettingService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{SiteSettingId}")]
        public DataActionResponse DeleteSiteSetting(int SiteSettingId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._SiteSettingService.DeleteSiteSetting(SiteSettingId).CreateDataActionResponseSuccessForDelete("SiteSettingId", SiteSettingId);
        }

        //get
        [HttpGet, Route("{SiteSettingId}")]
        public DataActionResponse Get(int SiteSettingId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SiteSettingService.GetSiteSettingBySiteSettingId(SiteSettingId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<SiteSettingViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SiteSettingService.GetSiteSetting(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(SiteSettingBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _SiteSettingService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._SiteSettingService.CreateSiteSetting(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{SiteSettingId}")]
        public DataActionResponse Put(SiteSettingBindingModel model, int SiteSettingId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _SiteSettingService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._SiteSettingService.UpdateSiteSetting(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

