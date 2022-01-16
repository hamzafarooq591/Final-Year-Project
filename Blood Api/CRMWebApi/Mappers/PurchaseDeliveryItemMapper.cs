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

    public static class PurchaseDeliveryItemMapper
    {
        public static PurchaseDeliveryItem ToEntity(this PurchaseDeliveryItemBindingModel model, int userId, PurchaseDeliveryItem original = null)
        {
            bool flag = original != null;
            PurchaseDeliveryItem company = flag ? model.Map<PurchaseDeliveryItemBindingModel, PurchaseDeliveryItem>(original) : model.Map<PurchaseDeliveryItemBindingModel, PurchaseDeliveryItem>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<PurchaseDeliveryItem>(userId);
            }
            return company.MapLastModifiedFields<PurchaseDeliveryItem>(userId);
        }
        public static NashPagedList<PurchaseDeliveryItemViewModel> ToViewModel(this IPagedList<PurchaseDeliveryItem> models)
        {
            List<PurchaseDeliveryItemViewModel> viewModels = new List<PurchaseDeliveryItemViewModel>();
            models.ToList<PurchaseDeliveryItem>().ForEach(delegate (PurchaseDeliveryItem a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PurchaseDeliveryItemViewModel>(models.GetMetaData());
        }

        public static List<PurchaseDeliveryItemViewModel> ToViewModel(this List<PurchaseDeliveryItem> models)
        {
            List<PurchaseDeliveryItemViewModel> viewModels = new List<PurchaseDeliveryItemViewModel>();
            models.ToList<PurchaseDeliveryItem>().ForEach(delegate (PurchaseDeliveryItem a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToList<PurchaseDeliveryItemViewModel>();
        }

        public static PurchaseDeliveryItemViewModel ToViewModel(this PurchaseDeliveryItem model)
        {
            return model.Map<PurchaseDeliveryItem, PurchaseDeliveryItemViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<PurchaseDeliveryItem, PurchaseDeliveryItemViewModel>()
                .ForMember(x => x.PurchaseDeliveryItemId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PurchaseDeliveryItemViewModel>(model);

        }
    }
}

