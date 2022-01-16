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

    public static class CurrencyMapper
    {
        public static Currency ToEntity(this CurrencyBindingModel model, int userId, Currency original = null)
        {
            bool flag = original != null;
            Currency location = flag ? model.Map<CurrencyBindingModel, Currency>(original) : model.Map<CurrencyBindingModel, Currency>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<Currency>(userId);
            }
            return location.MapLastModifiedFields<Currency>(userId);
        }

        public static CurrencyViewModel ToViewModel(this Currency model)
        {

            return model.Map<Currency, CurrencyViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<Currency, CurrencyViewModel>()
                .ForMember(x => x.CurrencyId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<CurrencyViewModel>(model);
        }
        public static NashPagedList<CurrencyViewModel> ToViewModel(this IPagedList<Currency> models)
        {
            List<CurrencyViewModel> viewModels = new List<CurrencyViewModel>();
            models.ToList<Currency>().ForEach(delegate (Currency a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<CurrencyViewModel>(models.GetMetaData());
        }

        public static IList<CurrencyViewModel> ToViewModel(this IList<Currency> models)
        {
            List<CurrencyViewModel> viewModels = new List<CurrencyViewModel>();
            models.ToList<Currency>().ForEach(delegate (Currency a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

