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

    [RoutePrefix("api/ClearingAgent")]
    public class ClearingAgentController : ApiController
    {
        private ClearingAgentService _ClearingAgentService = new ClearingAgentService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{ClearingAgentId}")]
        public DataActionResponse DeleteClearingAgent(int ClearingAgentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._ClearingAgentService.DeleteClearingAgent(ClearingAgentId).CreateDataActionResponseSuccessForDelete("ClearingAgentId", ClearingAgentId);
        }

        //get
        [HttpGet, Route("{ClearingAgentId}")]
        public DataActionResponse Get(int ClearingAgentId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ClearingAgentService.GetClearingAgentByClearingAgentId(ClearingAgentId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<ClearingAgentViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._ClearingAgentService.GetClearingAgent(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(ClearingAgentBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ClearingAgentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ClearingAgentService.CreateClearingAgent(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{ClearingAgentId}")]
        public DataActionResponse Put(ClearingAgentBindingModel model, int ClearingAgentId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _ClearingAgentService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._ClearingAgentService.UpdateClearingAgent(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

