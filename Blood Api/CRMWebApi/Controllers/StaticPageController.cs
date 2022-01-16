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

    [RoutePrefix("api/StaticPage")]
    public class StaticPageController : ApiController
    {
        private StaticPageService _StaticPageService = new StaticPageService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{StaticPageId}")]
        public DataActionResponse DeleteStaticPage(int StaticPageId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._StaticPageService.DeleteStaticPage(StaticPageId).CreateDataActionResponseSuccessForDelete("StaticPageId", StaticPageId);
        }

        //get
        [HttpGet, Route("{StaticPageId}")]
        public DataActionResponse Get(int StaticPageId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._StaticPageService.GetStaticPageByStaticPageId(StaticPageId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<StaticPageViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._StaticPageService.GetStaticPage(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(StaticPageBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _StaticPageService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._StaticPageService.CreateStaticPage(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{StaticPageId}")]
        public DataActionResponse Put(StaticPageBindingModel model, int StaticPageId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _StaticPageService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._StaticPageService.UpdateStaticPage(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

