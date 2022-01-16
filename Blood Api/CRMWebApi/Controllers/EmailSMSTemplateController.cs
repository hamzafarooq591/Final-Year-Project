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

    [RoutePrefix("api/EmailSMSTemplate")]
    public class EmailSMSTemplateController : ApiController
    {
        private EmailSMSTemplateService _EmailSMSTemplateService = new EmailSMSTemplateService();
        private NashUserService _nashUserService = new NashUserService();
        private int UserId = 1;

//delete
        [HttpPost, Route("Delete/{EmailSMSTemplateId}")]
        public DataActionResponse DeleteEmailSMSTemplate(int EmailSMSTemplateId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;

            return this._EmailSMSTemplateService.DeleteEmailSMSTemplate(EmailSMSTemplateId).CreateDataActionResponseSuccessForDelete("EmailSMSTemplateId", EmailSMSTemplateId);
        }

        //get
        [HttpGet, Route("{EmailSMSTemplateId}")]
        public DataActionResponse Get(int EmailSMSTemplateId)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmailSMSTemplateService.GetEmailSMSTemplateByEmailSMSTemplateId(EmailSMSTemplateId).CreateDataActionResponseSuccess();
        }
        //get all
        [HttpGet, Route("")]
        public NashPagedList<EmailSMSTemplateViewModel> Get(int size = 10, int page = 1)
        {
            var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            if (header == "")
                return null;
            var isSessionValid = _nashUserService.ValidateSession(header, UserId);
            if (isSessionValid == false)
                return null;
            return this._EmailSMSTemplateService.GetEmailSMSTemplate(size, page);
        }
        //save
        [HttpPost, Route("")]
        public DataActionResponse Post(EmailSMSTemplateBindingModel model)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmailSMSTemplateService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmailSMSTemplateService.CreateEmailSMSTemplate(model, this.UserId).CreateDataActionResponseSuccess();
        }

        //Update
        [HttpPost, Route("Put/{EmailSMSTemplateId}")]
        public DataActionResponse Put(EmailSMSTemplateBindingModel model, int EmailSMSTemplateId)
        {
            //var header = Request.Headers.Contains("token") ? ((string[])Request.Headers.GetValues("token"))[0] : "";
            //if (header == "")
            //    return null;
            //var isSessionValid = _EmailSMSTemplateService.ValidateSession(header, UserId);
            //if (isSessionValid == false)
            //    return null;
            return this._EmailSMSTemplateService.UpdateEmailSMSTemplate(model, this.UserId).CreateDataActionResponseSuccess();
        }
    }
}

