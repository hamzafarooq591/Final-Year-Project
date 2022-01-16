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

    public static class BranchMapper
    {
        public static Branch ToEntity(this BranchBindingModel model, int userId, Branch original = null)
        {
            bool flag = original != null;
            Branch company = flag ? model.Map<BranchBindingModel, Branch>(original) : model.Map<BranchBindingModel, Branch>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Branch>(userId);
            }
            return company.MapLastModifiedFields<Branch>(userId);
        }
        public static NashPagedList<BranchViewModel> ToViewModel(this IPagedList<Branch> models)
        {
            List<BranchViewModel> viewModels = new List<BranchViewModel>();
            models.ToList<Branch>().ForEach(delegate (Branch a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<BranchViewModel>(models.GetMetaData());
        }
        public static BranchViewModel ToViewModel(this Branch model)
        {
            return model.Map<Branch, BranchViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Branch, BranchViewModel>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Company.Name))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.BranchName));
            }).MapAuditableFields<BranchViewModel>(model);

        }
    }
}

