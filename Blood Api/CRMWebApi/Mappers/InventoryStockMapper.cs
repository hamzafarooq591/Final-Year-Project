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

    public static class InventoryStockMapper
    {
        public static InventoryStock ToEntity(this InventoryStockBindingModel model, int userId, InventoryStock original = null)
        {
            bool flag = original != null;
            InventoryStock location = flag ? model.Map<InventoryStockBindingModel, InventoryStock>(original) : model.Map<InventoryStockBindingModel, InventoryStock>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<InventoryStock>(userId);
            }
            return location.MapLastModifiedFields<InventoryStock>(userId);
        }

        public static InventoryStockViewModel ToViewModel(this InventoryStock model)
        {

            return model.Map<InventoryStock, InventoryStockViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<InventoryStock, InventoryStockViewModel>()
                .ForMember(x => x.InventoryStockId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<InventoryStockViewModel>(model);
        }
        public static NashPagedList<InventoryStockViewModel> ToViewModel(this IPagedList<InventoryStock> models)
        {
            List<InventoryStockViewModel> viewModels = new List<InventoryStockViewModel>();
            models.ToList<InventoryStock>().ForEach(delegate (InventoryStock a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<InventoryStockViewModel>(models.GetMetaData());
        }

        public static IList<InventoryStockViewModel> ToViewModel(this IList<InventoryStock> models)
        {
            List<InventoryStockViewModel> viewModels = new List<InventoryStockViewModel>();
            models.ToList<InventoryStock>().ForEach(delegate (InventoryStock a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

