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

    [RoutePrefix("api/NewsConfiguration")]
    public class NewsConfigurationController : ApiController
    {
        private NewsConfigurationService _NewsConfigurationService = new NewsConfigurationService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{NewsConfigurationId}")]
        public DataActionResponse DeleteNewsConfiguration(int NewsConfigurationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._NewsConfigurationService.DeleteNewsConfiguration(NewsConfigurationId).CreateDataActionResponseSuccessForDelete("NewsConfigurationId", NewsConfigurationId);
        }

        //get
        [HttpGet, Route("{NewsConfigurationId}")]
        public DataActionResponse Get(int NewsConfigurationId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsConfigurationService.GetNewsConfigurationByNewsConfigurationId(NewsConfigurationId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<NewsConfigurationViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsConfigurationService.GetNewsConfiguration(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(NewsConfigurationBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsConfigurationService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsConfigurationService.CreateNewsConfiguration(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{NewsConfigurationId}")]
        public DataActionResponse Put(NewsConfigurationBindingModel model, int NewsConfigurationId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsConfigurationService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsConfigurationService.UpdateNewsConfiguration(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

