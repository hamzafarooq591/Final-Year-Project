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

    [RoutePrefix("api/EmailTemplateType")]
    public class EmailTemplateTypeController : ApiController
    {
        private EmailTemplateTypeService _EmailTemplateTypeService = new EmailTemplateTypeService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{EmailTemplateTypeId}")]
        public DataActionResponse DeleteEmailTemplateType(int EmailTemplateTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmailTemplateTypeService.DeleteEmailTemplateType(EmailTemplateTypeId).CreateDataActionResponseSuccessForDelete("EmailTemplateTypeId", EmailTemplateTypeId);
        }

        //get
        [HttpGet, Route("{EmailTemplateTypeId}")]
        public DataActionResponse Get(int EmailTemplateTypeId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmailTemplateTypeService.GetEmailTemplateTypeByEmailTemplateTypeId(EmailTemplateTypeId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<EmailTemplateTypeViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmailTemplateTypeService.GetEmailTemplateType(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(EmailTemplateTypeBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmailTemplateTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmailTemplateTypeService.CreateEmailTemplateType(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{EmailTemplateTypeId}")]
        public DataActionResponse Put(EmailTemplateTypeBindingModel model, int EmailTemplateTypeId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmailTemplateTypeService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmailTemplateTypeService.UpdateEmailTemplateType(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

