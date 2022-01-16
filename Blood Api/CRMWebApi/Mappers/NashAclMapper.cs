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

    public static class NashAclMapper
    {
        public static NashAcl ToEntity(this NashAclBindingModel model, int userId, NashAcl original = null)
        {
            bool flag = original != null;
            NashAcl acl = flag ? model.Map<NashAclBindingModel, NashAcl>(original) : model.Map<NashAclBindingModel, NashAcl>();
            if (!flag)
            {
                return acl.MapCreatedAndLastModifiedFields<NashAcl>(userId);
            }
            return acl.MapLastModifiedFields<NashAcl>(userId);
        }

        public static NashAclViewModel ToViewModel(this NashAcl model)
        {
           return model.Map<NashAcl, NashAclViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<NashAcl, NashAclViewModel>()
                .ForMember(x => x.PageName, y => y.MapFrom(x => x.Page.Title))
                .ForMember(x => x.PageUrl, y => y.MapFrom(x => x.Page.Url))
                .ForMember(x => x.PageParentId, y => y.MapFrom(x => x.Page.ParentPageId))
                .ForMember(x => x.RoleName, y => y.MapFrom(x => x.Role.Name))
                .ForMember(x => x.NashAclId, y => y.MapFrom(x => x.Id));
                
            }).MapAuditableFields<NashAclViewModel>(model);
        }
        public static NashPagedList<NashAclViewModel> ToViewModel(this IPagedList<NashAcl> models)
        {
            List<NashAclViewModel> viewModels = new List<NashAclViewModel>();
            models.ToList<NashAcl>().ForEach(delegate (NashAcl a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<NashAclViewModel>(models.GetMetaData());
        }

        public static IList<NashAclViewModel> ToViewModel(this IList<NashAcl> models)
        {
            List<NashAclViewModel> viewModels = new List<NashAclViewModel>();
            models.ToList<NashAcl>().ForEach(delegate (NashAcl a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

        
    }
}

