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

    public static class ProductInStoreMapper
    {
        public static ProductInStore ToEntity(this ProductInStoreBindingModel model, int userId, ProductInStore original = null)
        {
            bool flag = original != null;
            ProductInStore company = flag ? model.Map<ProductInStoreBindingModel, ProductInStore>(original) : model.Map<ProductInStoreBindingModel, ProductInStore>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<ProductInStore>(userId);
            }
            return company.MapLastModifiedFields<ProductInStore>(userId);
        }
        public static NashPagedList<ProductInStoreViewModel> ToViewModel(this IPagedList<ProductInStore> models)
        {
            List<ProductInStoreViewModel> viewModels = new List<ProductInStoreViewModel>();
            models.ToList<ProductInStore>().ForEach(delegate (ProductInStore a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ProductInStoreViewModel>(models.GetMetaData());
        }
        public static ProductInStoreViewModel ToViewModel(this ProductInStore model)
        {
            return model.Map<ProductInStore, ProductInStoreViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<ProductInStore, ProductInStoreViewModel>()
                .ForMember(x => x.ProductId, y => y.MapFrom(x => x.Product.Id))
                .ForMember(x => x.BranchId, y => y.MapFrom(x => x.Branch.Id))
                .ForMember(x => x.PersonId, y => y.MapFrom(x => x.NashUser.Id))
                .ForMember(x => x.PersonName, y => y.MapFrom(x => x.NashUser.GetFullName()))
                .ForMember(x => x.ProductInStoreId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ProductInStoreViewModel>(model);

        }
    }
}

