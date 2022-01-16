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

    public static class ApprovalMapper
    {
        public static Approval ToEntity(this ApprovalBindingModel model, int userId, Approval original = null)
        {
            bool flag = original != null;
            Approval location = flag ? model.Map<ApprovalBindingModel, Approval>(original) : model.Map<ApprovalBindingModel, Approval>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<Approval>(userId);
            }
            return location.MapLastModifiedFields<Approval>(userId);
        }

        public static ApprovalViewModel ToViewModel(this Approval model)
        {

            return model.Map<Approval, ApprovalViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<Approval, ApprovalViewModel>()
                .ForMember(x => x.ApprovalId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ApprovalViewModel>(model);
        }
        public static NashPagedList<ApprovalViewModel> ToViewModel(this IPagedList<Approval> models)
        {
            List<ApprovalViewModel> viewModels = new List<ApprovalViewModel>();
            models.ToList<Approval>().ForEach(delegate (Approval a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ApprovalViewModel>(models.GetMetaData());
        }

        public static IList<ApprovalViewModel> ToViewModel(this IList<Approval> models)
        {
            List<ApprovalViewModel> viewModels = new List<ApprovalViewModel>();
            models.ToList<Approval>().ForEach(delegate (Approval a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

