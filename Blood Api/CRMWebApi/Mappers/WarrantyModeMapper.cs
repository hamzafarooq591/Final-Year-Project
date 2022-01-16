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

    public static class WarrantyModeMapper
    {
        public static WarrantyMode ToEntity(this WarrantyModeBindingModel model, int userId, WarrantyMode original = null)
        {
            bool flag = original != null;
            WarrantyMode location = flag ? model.Map<WarrantyModeBindingModel, WarrantyMode>(original) : model.Map<WarrantyModeBindingModel, WarrantyMode>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<WarrantyMode>(userId);
            }
            return location.MapLastModifiedFields<WarrantyMode>(userId);
        }

        public static WarrantyModeViewModel ToViewModel(this WarrantyMode model)
        {

            return model.Map<WarrantyMode, WarrantyModeViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<WarrantyMode, WarrantyModeViewModel>()
                .ForMember(x => x.WarrantyModeId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<WarrantyModeViewModel>(model);
        }
        public static NashPagedList<WarrantyModeViewModel> ToViewModel(this IPagedList<WarrantyMode> models)
        {
            List<WarrantyModeViewModel> viewModels = new List<WarrantyModeViewModel>();
            models.ToList<WarrantyMode>().ForEach(delegate (WarrantyMode a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<WarrantyModeViewModel>(models.GetMetaData());
        }

        public static IList<WarrantyModeViewModel> ToViewModel(this IList<WarrantyMode> models)
        {
            List<WarrantyModeViewModel> viewModels = new List<WarrantyModeViewModel>();
            models.ToList<WarrantyMode>().ForEach(delegate (WarrantyMode a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

