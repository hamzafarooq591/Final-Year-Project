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

    [RoutePrefix("api/FreightForwarder")]
    public class FreightForwarderController : ApiController
    {
        private FreightForwarderService _FreightForwarderService = new FreightForwarderService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{FreightForwarderId}")]
        public DataActionResponse DeleteFreightForwarder(int FreightForwarderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._FreightForwarderService.DeleteFreightForwarder(FreightForwarderId).CreateDataActionResponseSuccessForDelete("FreightForwarderId", FreightForwarderId);
        }

        //get
        [HttpGet, Route("{FreightForwarderId}")]
        public DataActionResponse Get(int FreightForwarderId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._FreightForwarderService.GetFreightForwarderByFreightForwarderId(FreightForwarderId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<FreightForwarderViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._FreightForwarderService.GetFreightForwarder(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(FreightForwarderBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _FreightForwarderService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._FreightForwarderService.CreateFreightForwarder(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{FreightForwarderId}")]
        public DataActionResponse Put(FreightForwarderBindingModel model, int FreightForwarderId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _FreightForwarderService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._FreightForwarderService.UpdateFreightForwarder(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

