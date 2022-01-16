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

    public static class DcSummaryMapper
    {
        public static DcSummary ToEntity(this DcSummaryBindingModel model, int userId, DcSummary original = null)
        {
            bool flag = original != null;
            DcSummary company = flag ? model.Map<DcSummaryBindingModel, DcSummary>(original) : model.Map<DcSummaryBindingModel, DcSummary>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<DcSummary>(userId);
            }
            return company.MapLastModifiedFields<DcSummary>(userId);
        }
        public static NashPagedList<DcSummaryViewModel> ToViewModel(this IPagedList<DcSummary> models)
        {
            List<DcSummaryViewModel> viewModels = new List<DcSummaryViewModel>();
            models.ToList<DcSummary>().ForEach(delegate (DcSummary a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<DcSummaryViewModel>(models.GetMetaData());
        }
        public static DcSummaryViewModel ToViewModel(this DcSummary model)
        {
            return model.Map<DcSummary, DcSummaryViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<DcSummary, DcSummaryViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Branch.Id))
                .ForMember(x => x.DcGroupId, y => y.MapFrom(x => x.DcGroup.Id))
                .ForMember(x => x.DcGroupTitle, y => y.MapFrom(x => x.DcGroup.DcGroupTitle))
                .ForMember(x => x.DcSummaryId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<DcSummaryViewModel>(model);

        }
    }
}

