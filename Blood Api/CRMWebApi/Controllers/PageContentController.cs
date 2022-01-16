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

    [RoutePrefix("api/PageContent")]
    public class PageContentController : ApiController
    {
        private PageContentService _PageContentService = new PageContentService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{PageContentId}")]
        public DataActionResponse DeletePageContent(int PageContentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PageContentService.DeletePageContent(PageContentId).CreateDataActionResponseSuccessForDelete("PageContentId", PageContentId);
        }

        //get
        [HttpGet, Route("{PageContentId}")]
        public DataActionResponse Get(int PageContentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PageContentService.GetPageContentByPageContentId(PageContentId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<PageContentViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._PageContentService.GetPageContent(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(PageContentBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PageContentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PageContentService.CreatePageContent(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{PageContentId}")]
        public DataActionResponse Put(PageContentBindingModel model, int PageContentId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _PageContentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._PageContentService.UpdatePageContent(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

