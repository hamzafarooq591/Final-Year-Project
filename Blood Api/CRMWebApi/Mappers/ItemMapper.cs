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

    public static class ItemMapper
    {
        public static Item ToEntity(this ItemBindingModel model, int userId, Item original = null)
        {
            bool flag = original != null;
            Item company = flag ? model.Map<ItemBindingModel, Item>(original) : model.Map<ItemBindingModel, Item>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Item>(userId);
            }
            return company.MapLastModifiedFields<Item>(userId);
        }
        public static NashPagedList<ItemViewModel> ToViewModel(this IPagedList<Item> models)
        {
            List<ItemViewModel> viewModels = new List<ItemViewModel>();
            models.ToList<Item>().ForEach(delegate (Item a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ItemViewModel>(models.GetMetaData());
        }
        public static ItemViewModel ToViewModel(this Item model)
        {
            return model.Map<Item, ItemViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Item, ItemViewModel>()
                .ForMember(x => x.ItemId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ItemViewModel>(model);

        }
    }
}

