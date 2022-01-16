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

    public static class NashUserMapper
    {
        public static NashUser ToEntity(this NashUserBindingModel model, int userId, NashUser original = null)
        {
            bool flag = original != null;
            NashUser user = flag ? model.Map<NashUserBindingModel, NashUser>(original) : model.Map<NashUserBindingModel, NashUser>();
            if (!flag)
            {
                return user.MapCreatedAndLastModifiedFields<NashUser>(userId);
            }
            return user.MapLastModifiedFields<NashUser>(userId);
        }
        //new
        public static NashRole ToEntity(this NashRolesBindingModel model, int userId, NashRole original = null)
        {
            bool flag = original != null;
            NashRole role= flag ? model.Map<NashRolesBindingModel, NashRole>(original) : model.Map<NashRolesBindingModel, NashRole>();
            if (!flag)
            {
                return role.MapCreatedAndLastModifiedFields<NashRole>(userId);
            }
            return role.MapLastModifiedFields<NashRole>(userId);
        }
        ///end
        // NashUserType
        public static NashUserType ToEntity(this NashUserTypeBindingModel model, int userId, NashUserType original = null)
        {
            bool flag = original != null;
            NashUserType role = flag ? model.Map<NashUserTypeBindingModel, NashUserType>(original) : model.Map<NashUserTypeBindingModel, NashUserType>();
            if (!flag)
            {
                return role.MapCreatedAndLastModifiedFields<NashUserType>(userId);
            }
            return role.MapLastModifiedFields<NashUserType>(userId);
        }
        //End NashUserType
        public static NashUser ToEntity(this NashUserRegistrationBindingModel model, int userId, NashUser original = null)
        {
            bool flag = original != null;
            NashUser user = flag ? model.Map<NashUserRegistrationBindingModel, NashUser>(original) : model.Map<NashUserRegistrationBindingModel, NashUser>();
            if (!flag)
            {
                return user.MapCreatedAndLastModifiedFields<NashUser>(userId);
            }
            return user.MapLastModifiedFields<NashUser>(userId);
        }

        public static IList<NashUserTypeViewModel> ToUserTypeViewModel(this IList<NashUserType> models)
        {
            List<NashUserTypeViewModel> viewModels = new List<NashUserTypeViewModel>();
            models.ToList<NashUserType>().ForEach(delegate (NashUserType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

        public static NashUserViewModel ToViewModel(this NashUser model)
        {
            return model.Map<NashUser, NashUserViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<NashUser, NashUserViewModel>()
                .ForMember(x => x.NashUserType, y => y.MapFrom(x => x.NashUserType.Name))
                .ForMember(x => x.City, y => y.MapFrom(x => x.City.CityName))
                .ForMember(x => x.NashUserId, y => y.MapFrom(x => x.Id))
                .ForMember(x => x.Gender, y => y.MapFrom(x => x.Gender.Name))
                .ForMember(x => x.BranchName, y => y.MapFrom(x => x.Branch.BranchName))
                .ForMember(x => x.FullName, y => y.MapFrom(x => x.GetFullName()));
            }).MapAuditableFields<NashUserViewModel>(model);
        }
        public static NashUserTypeViewModel ToViewModel(this NashUserType model) => 
            model.Map<NashUserType, NashUserTypeViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<NashUserType, NashUserTypeViewModel>();//changes both from nashuser to nashusertype
            }).MapAuditableFields<NashUserTypeViewModel>(model);

        public static NashPagedList<NashUserViewModel> ToViewModel(this IPagedList<NashUser> models)
        {
            List<NashUserViewModel> viewModels = new List<NashUserViewModel>();
            models.ToList<NashUser>().ForEach(delegate (NashUser a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NashUserViewModel>(models.GetMetaData());
        }

        public static IList<NashUserViewModel> ToViewModel(this IList<NashUser> models)
        {
            List<NashUserViewModel> viewModels = new List<NashUserViewModel>();
            models.ToList<NashUser>().ForEach(delegate (NashUser a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

        public static IList<NashUserTypeViewModel> ToViewModel(this IList<NashUserType> models)
        {
            List<NashUserTypeViewModel> viewModels = new List<NashUserTypeViewModel>();
            models.ToList<NashUserType>().ForEach(delegate (NashUserType a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToList<NashUserTypeViewModel>();
        }
    }
}

