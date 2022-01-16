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

    public static class BillToTypeMapper
    {
        public static BillToType ToEntity(this BillToTypeBindingModel model, int userId, BillToType original = null)
        {
            bool flag = original != null;
            BillToType location = flag ? model.Map<BillToTypeBindingModel, BillToType>(original) : model.Map<BillToTypeBindingModel, BillToType>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<BillToType>(userId);
            }
            return location.MapLastModifiedFields<BillToType>(userId);
        }

        public static BillToTypeViewModel ToViewModel(this BillToType model)
        {

            return model.Map<BillToType, BillToTypeViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<BillToType, BillToTypeViewModel>()
                .ForMember(x => x.BillToTypeId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<BillToTypeViewModel>(model);
        }
        public static NashPagedList<BillToTypeViewModel> ToViewModel(this IPagedList<BillToType> models)
        {
            List<BillToTypeViewModel> viewModels = new List<BillToTypeViewModel>();
            models.ToList<BillToType>().ForEach(delegate (BillToType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<BillToTypeViewModel>(models.GetMetaData());
        }

        public static IList<BillToTypeViewModel> ToViewModel(this IList<BillToType> models)
        {
            List<BillToTypeViewModel> viewModels = new List<BillToTypeViewModel>();
            models.ToList<BillToType>().ForEach(delegate (BillToType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

