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

    [RoutePrefix("api/NewsList")]
    public class NewsListController : ApiController
    {
        private NewsListService _NewsListService = new NewsListService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{NewsListId}")]
        public DataActionResponse DeleteNewsList(int NewsListId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsListService.DeleteNewsList(NewsListId).CreateDataActionResponseSuccessForDelete("NewsListId", NewsListId);
        }

        //get
        [HttpGet, Route("{NewsListId}")]
        public DataActionResponse Get(int NewsListId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsListService.GetNewsListByNewsListId(NewsListId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<NewsListViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NewsListService.GetNewsList(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(NewsListBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsListService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsListService.CreateNewsList(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{NewsListId}")]
        public DataActionResponse Put(NewsListBindingModel model, int NewsListId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _NewsListService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._NewsListService.UpdateNewsList(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

