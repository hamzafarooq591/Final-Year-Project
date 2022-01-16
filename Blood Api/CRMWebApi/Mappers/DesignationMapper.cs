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

    public static class DesignationMapper
    {
        public static Designation ToEntity(this DesignationBindingModel model, int userId, Designation original = null)
        {
            bool flag = original != null;
            Designation location = flag ? model.Map<DesignationBindingModel, Designation>(original) : model.Map<DesignationBindingModel, Designation>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<Designation>(userId);
            }
            return location.MapLastModifiedFields<Designation>(userId);
        }

        public static DesignationViewModel ToViewModel(this Designation model)
        {

            return model.Map<Designation, DesignationViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<Designation, DesignationViewModel>()
                .ForMember(x => x.DesignationId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<DesignationViewModel>(model);
        }
        public static NashPagedList<DesignationViewModel> ToViewModel(this IPagedList<Designation> models)
        {
            List<DesignationViewModel> viewModels = new List<DesignationViewModel>();
            models.ToList<Designation>().ForEach(delegate (Designation a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<DesignationViewModel>(models.GetMetaData());
        }

        public static IList<DesignationViewModel> ToViewModel(this IList<Designation> models)
        {
            List<DesignationViewModel> viewModels = new List<DesignationViewModel>();
            models.ToList<Designation>().ForEach(delegate (Designation a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

