namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IEmailTemplateTypeService
    {
        EmailTemplateTypeViewModel CreateEmailTemplateType(EmailTemplateTypeBindingModel model, int userId);
        bool DeleteEmailTemplateType(int EmailTemplateTypeId);
        EmailTemplateTypeViewModel GetEmailTemplateTypeByEmailTemplateTypeId(int EmailTemplateTypeId);
        NashPagedList<EmailTemplateTypeViewModel> GetEmailTemplateType(int rows, int pageNumber );
        EmailTemplateTypeViewModel UpdateEmailTemplateType(EmailTemplateTypeBindingModel model, int userId);
    }
}

