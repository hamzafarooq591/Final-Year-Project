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

    [RoutePrefix("api/NewsLetterTemplate")]
    public class NewsLetterTemplateController : ApiController
    {
        private NewsLetterTemplateService _NewsLetterTemplateService = new NewsLetterTemplateService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{NewsLetterTemplateId}")]
        public DataActionResponse DeleteNewsLetterTemplate(int NewsLetterTemplateId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._NewsLetterTemplateService.DeleteNewsLetterTemplate(NewsLetterTemplateId).CreateDataActionResponseSuccessForDelete("NewsLetterTemplateId", NewsLetterTemplateId);
        }

        //get
        [HttpGet, Route("{NewsLetterTemplateId}")]
        public DataActionResponse Get(int NewsLetterTemplateId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsLetterTemplateService.GetNewsLetterTemplateByNewsLetterTemplateId(NewsLetterTemplateId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<NewsLetterTemplateViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsLetterTemplateService.GetNewsLetterTemplate(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(NewsLetterTemplateBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsLetterTemplateService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsLetterTemplateService.CreateNewsLetterTemplate(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{NewsLetterTemplateId}")]
        public DataActionResponse Put(NewsLetterTemplateBindingModel model, int NewsLetterTemplateId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsLetterTemplateService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsLetterTemplateService.UpdateNewsLetterTemplate(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

