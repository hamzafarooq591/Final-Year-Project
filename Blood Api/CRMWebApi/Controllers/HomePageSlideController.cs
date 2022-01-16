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

    [RoutePrefix("api/HomePageSlide")]
    public class HomePageSlideController : ApiController
    {
       // private HomePageSlideService _anufacturerService = new CompanyService();
        private HomePageSlideService _HomePageSlideService = new HomePageSlideService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;
//delete
        [HttpPost, Route("Delete/{HomePageSlideId}")]
        public DataActionResponse DeleteHomePageSlide(int HomePageSlideId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._HomePageSlideService.DeleteHomePageSlide(HomePageSlideId).CreateDataActionResponseSuccessForDelete("HomePageSlideId", HomePageSlideId);
        }

        //get
        [HttpGet, Route("{HomePageSlideId}")]
        public DataActionResponse Get(int HomePageSlideId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._HomePageSlideService.GetHomePageSlideByHomePageSlideId(HomePageSlideId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<HomePageSlideViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._HomePageSlideService.GetHomePageSlide(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(HomePageSlideBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _HomePageSlideService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._HomePageSlideService.CreateHomePageSlide(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{HomePageSlideId}")]
        public DataActionResponse Put(HomePageSlideBindingModel model, int HomePageSlideId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._HomePageSlideService.UpdateHomePageSlide(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

