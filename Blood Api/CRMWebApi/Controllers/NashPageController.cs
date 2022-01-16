namespace NashWebApi.Controllers
{
    using NashWebApi.BindingModels;
    using NashWebApi.Exceptions;
    using NashWebApi.Extensions;
    using NashWebApi.Services;
    using NashWebApi.ViewModels;
    using System;
    using System.Runtime.InteropServices;
    using System.Web.Http;

    [RoutePrefix("api/NashPage")]
    public class NashPageController : ApiController
    {
        private NashPageService _NashPageService = new NashPageService();
        private NashUserService _NashUserService = new NashUserService();
        private int UserId = 1;

        [HttpPost, Route("Delete/{nashPageId}")]
        public DataActionResponse DeleteNashPage(int nashPageId)
        {
            return this._NashPageService.DeleteNashPage(nashPageId).CreateDataActionResponseSuccessForDelete("NashPageId", nashPageId);
        }

        [HttpGet, Route("{NashPageId}")]
        public DataActionResponse Get(int NashPageId)
        {
            return this._NashPageService.GetNashPageByNashPageId(NashPageId).CreateDataActionResponseSuccess();
        }

        [HttpGet, Route("")]
        public NashPagedList<NashPageViewModel> Get(int size = 0x3e8, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";

            if (header == "")
                return null;

            var isSessionValid = _NashUserService.ValidateSession(header, UserId);

            if (isSessionValid == false)
                return null;

            return _NashPageService.GetNashPages(size, page);
        }

        [HttpPost, Route("")]
        public DataActionResponse Post(NashPageBindingModel model)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _NashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._NashPageService.CreateNashPage(model, this.UserId).CreateDataActionResponseSuccess();
        }

        [HttpPost, Route("Put/{nashPageId}")]
        public DataActionResponse Put(NashPageBindingModel model, int nashPageId)
        {
            return this._NashPageService.UpdateNashPage(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

