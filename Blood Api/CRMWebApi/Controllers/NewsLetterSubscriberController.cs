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

    [RoutePrefix("api/NewsLetterSubscriber")]
    public class NewsLetterSubscriberController : ApiController
    {
        private NewsLetterSubscriberService _NewsLetterSubscriberService = new NewsLetterSubscriberService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{NewsLetterSubscriberId}")]
        public DataActionResponse DeleteNewsLetterSubscriber(int NewsLetterSubscriberId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsLetterSubscriberService.DeleteNewsLetterSubscriber(NewsLetterSubscriberId).CreateDataActionResponseSuccessForDelete("NewsLetterSubscriberId", NewsLetterSubscriberId);
        }

        //get
        [HttpGet, Route("{NewsLetterSubscriberId}")]
        public DataActionResponse Get(int NewsLetterSubscriberId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsLetterSubscriberService.GetNewsLetterSubscriberByNewsLetterSubscriberId(NewsLetterSubscriberId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<NewsLetterSubscriberViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsLetterSubscriberService.GetNewsLetterSubscriber(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(NewsLetterSubscriberBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsLetterSubscriberService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsLetterSubscriberService.CreateNewsLetterSubscriber(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{NewsLetterSubscriberId}")]
        public DataActionResponse Put(NewsLetterSubscriberBindingModel model, int NewsLetterSubscriberId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsLetterSubscriberService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsLetterSubscriberService.UpdateNewsLetterSubscriber(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

