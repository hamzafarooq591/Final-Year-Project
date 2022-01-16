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

    public static class SaleDeliveryItemMapper
    {
        public static SaleDeliveryItem ToEntity(this SaleDeliveryItemBindingModel model, int userId, SaleDeliveryItem original = null)
        {
            bool flag = original != null;
            SaleDeliveryItem company = flag ? model.Map<SaleDeliveryItemBindingModel, SaleDeliveryItem>(original) : model.Map<SaleDeliveryItemBindingModel, SaleDeliveryItem>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<SaleDeliveryItem>(userId);
            }
            return company.MapLastModifiedFields<SaleDeliveryItem>(userId);
        }
        public static NashPagedList<SaleDeliveryItemViewModel> ToViewModel(this IPagedList<SaleDeliveryItem> models)
        {
            List<SaleDeliveryItemViewModel> viewModels = new List<SaleDeliveryItemViewModel>();
            models.ToList<SaleDeliveryItem>().ForEach(delegate (SaleDeliveryItem a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<SaleDeliveryItemViewModel>(models.GetMetaData());
        }
        public static List<SaleDeliveryItemViewModel> ToViewModel(this List<SaleDeliveryItem> models)
        {
            List<SaleDeliveryItemViewModel> viewModels = new List<SaleDeliveryItemViewModel>();
            models.ToList<SaleDeliveryItem>().ForEach(delegate (SaleDeliveryItem a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToList<SaleDeliveryItemViewModel>();
        }
        public static SaleDeliveryItemViewModel ToViewModel(this SaleDeliveryItem model)
        {
            return model.Map<SaleDeliveryItem, SaleDeliveryItemViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<SaleDeliveryItem, SaleDeliveryItemViewModel>()
                .ForMember(x => x.SaleDeliveryItemId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<SaleDeliveryItemViewModel>(model);

        }
    }
}

