namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IEmailSMSTemplateService
    {
        EmailSMSTemplateViewModel CreateEmailSMSTemplate(EmailSMSTemplateBindingModel model, int userId);
        bool DeleteEmailSMSTemplate(int EmailSMSTemplateId);
        EmailSMSTemplateViewModel GetEmailSMSTemplateByEmailSMSTemplateId(int EmailSMSTemplateId);
        NashPagedList<EmailSMSTemplateViewModel> GetEmailSMSTemplate(int rows, int pageNumber);
        EmailSMSTemplateViewModel UpdateEmailSMSTemplate(EmailSMSTemplateBindingModel model, int userId);
    }
}

