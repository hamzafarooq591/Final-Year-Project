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

    public static class InvoiceSummaryMapper
    {
        public static InvoiceSummary ToEntity(this InvoiceSummaryBindingModel model, int userId, InvoiceSummary original = null)
        {
            bool flag = original != null;
            InvoiceSummary location = flag ? model.Map<InvoiceSummaryBindingModel, InvoiceSummary>(original) : model.Map<InvoiceSummaryBindingModel, InvoiceSummary>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<InvoiceSummary>(userId);
            }
            return location.MapLastModifiedFields<InvoiceSummary>(userId);
        }

        public static InvoiceSummaryViewModel ToViewModel(this InvoiceSummary model)
        {

            return model.Map<InvoiceSummary, InvoiceSummaryViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<InvoiceSummary, InvoiceSummaryViewModel>()
                .ForMember(x => x.InvoiceSummaryId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<InvoiceSummaryViewModel>(model);
        }
        public static NashPagedList<InvoiceSummaryViewModel> ToViewModel(this IPagedList<InvoiceSummary> models)
        {
            List<InvoiceSummaryViewModel> viewModels = new List<InvoiceSummaryViewModel>();
            models.ToList<InvoiceSummary>().ForEach(delegate (InvoiceSummary a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<InvoiceSummaryViewModel>(models.GetMetaData());
        }

        public static IList<InvoiceSummaryViewModel> ToViewModel(this IList<InvoiceSummary> models)
        {
            List<InvoiceSummaryViewModel> viewModels = new List<InvoiceSummaryViewModel>();
            models.ToList<InvoiceSummary>().ForEach(delegate (InvoiceSummary a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

