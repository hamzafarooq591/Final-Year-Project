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

    public static class DcGroupMapper
    {
        public static DcGroup ToEntity(this DcGroupBindingModel model, int userId, DcGroup original = null)
        {
            bool flag = original != null;
            DcGroup location = flag ? model.Map<DcGroupBindingModel, DcGroup>(original) : model.Map<DcGroupBindingModel, DcGroup>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<DcGroup>(userId);
            }
            return location.MapLastModifiedFields<DcGroup>(userId);
        }

        public static DcGroupViewModel ToViewModel(this DcGroup model)
        {

            return model.Map<DcGroup, DcGroupViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<DcGroup, DcGroupViewModel>()
                .ForMember(x => x.DcGroupId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<DcGroupViewModel>(model);
        }
        public static NashPagedList<DcGroupViewModel> ToViewModel(this IPagedList<DcGroup> models)
        {
            List<DcGroupViewModel> viewModels = new List<DcGroupViewModel>();
            models.ToList<DcGroup>().ForEach(delegate (DcGroup a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<DcGroupViewModel>(models.GetMetaData());
        }

        public static IList<DcGroupViewModel> ToViewModel(this IList<DcGroup> models)
        {
            List<DcGroupViewModel> viewModels = new List<DcGroupViewModel>();
            models.ToList<DcGroup>().ForEach(delegate (DcGroup a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

