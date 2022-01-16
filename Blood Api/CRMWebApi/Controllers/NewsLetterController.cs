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

    [RoutePrefix("api/NewsLetter")]
    public class NewsLetterController : ApiController
    {
        private NewsLetterService _NewsLetterService = new NewsLetterService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{NewsLetterId}")]
        public DataActionResponse DeleteNewsLetter(int NewsLetterId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._NewsLetterService.DeleteNewsLetter(NewsLetterId).CreateDataActionResponseSuccessForDelete("NewsLetterId", NewsLetterId);
        }

        //get
        [HttpGet, Route("{NewsLetterId}")]
        public DataActionResponse Get(int NewsLetterId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsLetterService.GetNewsLetterByNewsLetterId(NewsLetterId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<NewsLetterViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsLetterService.GetNewsLetter(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(NewsLetterBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsLetterService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsLetterService.CreateNewsLetter(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{NewsLetterId}")]
        public DataActionResponse Put(NewsLetterBindingModel model, int NewsLetterId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsLetterService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsLetterService.UpdateNewsLetter(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

