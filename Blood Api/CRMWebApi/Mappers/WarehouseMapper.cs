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

    public static class WarehouseMapper
    {
        public static Warehouse ToEntity(this WarehouseBindingModel model, int userId, Warehouse original = null)
        {
            bool flag = original != null;
            Warehouse company = flag ? model.Map<WarehouseBindingModel, Warehouse>(original) : model.Map<WarehouseBindingModel, Warehouse>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Warehouse>(userId);
            }
            return company.MapLastModifiedFields<Warehouse>(userId);
        }
        public static NashPagedList<WarehouseViewModel> ToViewModel(this IPagedList<Warehouse> models)
        {
            List<WarehouseViewModel> viewModels = new List<WarehouseViewModel>();
            models.ToList<Warehouse>().ForEach(delegate (Warehouse a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<WarehouseViewModel>(models.GetMetaData());
        }
        public static WarehouseViewModel ToViewModel(this Warehouse model)
        {
            return model.Map<Warehouse, WarehouseViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Warehouse, WarehouseViewModel>()
                .ForMember(x => x.WarehouseId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<WarehouseViewModel>(model);

        }
    }
}

