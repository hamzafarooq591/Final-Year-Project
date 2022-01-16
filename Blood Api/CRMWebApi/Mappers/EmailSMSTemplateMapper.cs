namespace NashWebApi.Mappers
{
    using AutoMapper;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Runtime.InteropServices;

    public static class EmailSMSTemplateMapper
    {
        public static EmailSMSTemplate ToEntity(this EmailSMSTemplateBindingModel model, int userId, EmailSMSTemplate original = null)
        {
            bool flag = original != null;
            EmailSMSTemplate company = flag ? model.Map<EmailSMSTemplateBindingModel, EmailSMSTemplate>(original) : model.Map<EmailSMSTemplateBindingModel, EmailSMSTemplate>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<EmailSMSTemplate>(userId);
            }
            return company.MapLastModifiedFields<EmailSMSTemplate>(userId);
        }
        public static NashPagedList<EmailSMSTemplateViewModel> ToViewModel(this IPagedList<EmailSMSTemplate> models)
        {
            List<EmailSMSTemplateViewModel> viewModels = new List<EmailSMSTemplateViewModel>();
            models.ToList<EmailSMSTemplate>().ForEach(delegate (EmailSMSTemplate a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<EmailSMSTemplateViewModel>(models.GetMetaData());
        }
        public static EmailSMSTemplateViewModel ToViewModel(this EmailSMSTemplate model)
        {
            return model.Map<EmailSMSTemplate, EmailSMSTemplateViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<EmailSMSTemplate, EmailSMSTemplateViewModel>()
                .ForMember(x => x.TemplateType, y => y.MapFrom(x => x.EmailTemplateType.TemplateType))
                .ForMember(x => x.EmailSMSTemplateId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.EmailTemplateTypeId, y => y.MapFrom(x => x.EmailTemplateType.Id));
            }).MapAuditableFields<EmailSMSTemplateViewModel>(model);

        }
    }
}

