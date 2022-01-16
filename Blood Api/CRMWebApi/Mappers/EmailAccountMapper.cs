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

    public static class EmailAccountMapper
    {
        public static EmailAccount ToEntity(this EmailAccountBindingModel model, int userId, EmailAccount original = null)
        {
            bool flag = original != null;
            EmailAccount location = flag ? model.Map<EmailAccountBindingModel, EmailAccount>(original) : model.Map<EmailAccountBindingModel, EmailAccount>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<EmailAccount>(userId);
            }
            return location.MapLastModifiedFields<EmailAccount>(userId);
        }

        public static EmailAccountViewModel ToViewModel(this EmailAccount model)
        {

            return model.Map<EmailAccount, EmailAccountViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<EmailAccount, EmailAccountViewModel>()
                .ForMember(x => x.EmailAccountId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<EmailAccountViewModel>(model);
        }
        public static NashPagedList<EmailAccountViewModel> ToViewModel(this IPagedList<EmailAccount> models)
        {
            List<EmailAccountViewModel> viewModels = new List<EmailAccountViewModel>();
            models.ToList<EmailAccount>().ForEach(delegate (EmailAccount a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<EmailAccountViewModel>(models.GetMetaData());
        }

        public static IList<EmailAccountViewModel> ToViewModel(this IList<EmailAccount> models)
        {
            List<EmailAccountViewModel> viewModels = new List<EmailAccountViewModel>();
            models.ToList<EmailAccount>().ForEach(delegate (EmailAccount a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

