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

    public static class MissingItemMapper
    {
        public static MissingItem ToEntity(this MissingItemBindingModel model, int userId, MissingItem original = null)
        {
            bool flag = original != null;
            MissingItem company = flag ? model.Map<MissingItemBindingModel, MissingItem>(original) : model.Map<MissingItemBindingModel, MissingItem>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<MissingItem>(userId);
            }
            return company.MapLastModifiedFields<MissingItem>(userId);
        }
        public static NashPagedList<MissingItemViewModel> ToViewModel(this IPagedList<MissingItem> models)
        {
            List<MissingItemViewModel> viewModels = new List<MissingItemViewModel>();
            models.ToList<MissingItem>().ForEach(delegate (MissingItem a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<MissingItemViewModel>(models.GetMetaData());
        }
        public static MissingItemViewModel ToViewModel(this MissingItem model)
        {
            return model.Map<MissingItem, MissingItemViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<MissingItem, MissingItemViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Branch.Id))
                .ForMember(x => x.MissingItemId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<MissingItemViewModel>(model);

        }
    }
}

