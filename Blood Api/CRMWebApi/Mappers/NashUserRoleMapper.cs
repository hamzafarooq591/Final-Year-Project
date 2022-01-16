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

    public static class NashUserRoleMapper
    {
        public static NashUserRole ToEntity(this NashUserRoleBindingModel model, int userId, NashUserRole original = null)
        {
            bool flag = original != null;
            NashUserRole role = flag ? model.Map<NashUserRoleBindingModel, NashUserRole>(original) : model.Map<NashUserRoleBindingModel, NashUserRole>();
            if (!flag)
            {
                return role.MapCreatedAndLastModifiedFields<NashUserRole>(userId);
            }
            return role.MapLastModifiedFields<NashUserRole>(userId);
        }

        public static NashUserRoleViewModel ToViewModel(this NashUserRole model)
        {

            return model.Map<NashUserRole, NashUserRoleViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<NashUserRole, NashUserRoleViewModel>()
                .ForMember(x => x.NashRoleName, y => y.MapFrom(x => x.NashRole.Name))
                .ForMember(x => x.NashUserName, y => y.MapFrom(x => x.NashUser.GetFullName()))
                .ForMember(x => x.NashUserRoleId,y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<NashUserRoleViewModel>(model);



        }
        public static NashPagedList<NashUserRoleViewModel> ToViewModel(this IPagedList<NashUserRole> models)
        {
            List<NashUserRoleViewModel> viewModels = new List<NashUserRoleViewModel>();
            models.ToList<NashUserRole>().ForEach(delegate (NashUserRole a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NashUserRoleViewModel>(models.GetMetaData());
        }

        public static IList<NashUserRoleViewModel> ToViewModel(this IList<NashUserRole> models)
        {
            List<NashUserRoleViewModel> viewModels = new List<NashUserRoleViewModel>();
            models.ToList<NashUserRole>().ForEach(delegate (NashUserRole a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

