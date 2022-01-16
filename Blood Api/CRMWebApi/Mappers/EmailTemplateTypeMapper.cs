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

    public static class EmailTemplateTypeMapper
    {
        public static EmailTemplateType ToEntity(this EmailTemplateTypeBindingModel model, int userId, EmailTemplateType original = null)
        {
            bool flag = original != null;
            EmailTemplateType location = flag ? model.Map<EmailTemplateTypeBindingModel, EmailTemplateType>(original) : model.Map<EmailTemplateTypeBindingModel, EmailTemplateType>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<EmailTemplateType>(userId);
            }
            return location.MapLastModifiedFields<EmailTemplateType>(userId);
        }

        public static EmailTemplateTypeViewModel ToViewModel(this EmailTemplateType model)
        {

            return model.Map<EmailTemplateType, EmailTemplateTypeViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<EmailTemplateType, EmailTemplateTypeViewModel>()
                .ForMember(x => x.EmailTemplateTypeId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<EmailTemplateTypeViewModel>(model);
        }
        public static NashPagedList<EmailTemplateTypeViewModel> ToViewModel(this IPagedList<EmailTemplateType> models)
        {
            List<EmailTemplateTypeViewModel> viewModels = new List<EmailTemplateTypeViewModel>();
            models.ToList<EmailTemplateType>().ForEach(delegate (EmailTemplateType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<EmailTemplateTypeViewModel>(models.GetMetaData());
        }

        public static IList<EmailTemplateTypeViewModel> ToViewModel(this IList<EmailTemplateType> models)
        {
            List<EmailTemplateTypeViewModel> viewModels = new List<EmailTemplateTypeViewModel>();
            models.ToList<EmailTemplateType>().ForEach(delegate (EmailTemplateType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

