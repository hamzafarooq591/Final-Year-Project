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

    [RoutePrefix("api/SmsType")]
    public class SmsTypeController : ApiController
    {
        private SmsTypeService _SmsTypeService = new SmsTypeService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{SmsTypeId}")]
        public DataActionResponse DeleteSmsType(int SmsTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._SmsTypeService.DeleteSmsType(SmsTypeId).CreateDataActionResponseSuccessForDelete("SmsTypeId", SmsTypeId);
        }

        //get
        [HttpGet, Route("{SmsTypeId}")]
        public DataActionResponse Get(int SmsTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SmsTypeService.GetSmsTypeBySmsTypeId(SmsTypeId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<SmsTypeViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._SmsTypeService.GetSmsType(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(SmsTypeBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _SmsTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._SmsTypeService.CreateSmsType(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{SmsTypeId}")]
        public DataActionResponse Put(SmsTypeBindingModel model, int SmsTypeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _SmsTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._SmsTypeService.UpdateSmsType(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

