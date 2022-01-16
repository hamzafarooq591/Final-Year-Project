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

    public static class WarrantyRequestStatusMapper
    {
        public static WarrantyRequestStatus ToEntity(this WarrantyRequestStatusBindingModel model, int userId, WarrantyRequestStatus original = null)
        {
            bool flag = original != null;
            WarrantyRequestStatus location = flag ? model.Map<WarrantyRequestStatusBindingModel, WarrantyRequestStatus>(original) : model.Map<WarrantyRequestStatusBindingModel, WarrantyRequestStatus>();
            if (!flag)
            {
                return location.MapCreatedAndLastModifiedFields<WarrantyRequestStatus>(userId);
            }
            return location.MapLastModifiedFields<WarrantyRequestStatus>(userId);
        }

        public static WarrantyRequestStatusViewModel ToViewModel(this WarrantyRequestStatus model)
        {

            return model.Map<WarrantyRequestStatus, WarrantyRequestStatusViewModel>(delegate (IMapperConfigurationExpression cfg)
            {
                cfg.CreateMap<WarrantyRequestStatus, WarrantyRequestStatusViewModel>()
                .ForMember(x => x.WarrantyRequestStatusId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<WarrantyRequestStatusViewModel>(model);
        }
        public static NashPagedList<WarrantyRequestStatusViewModel> ToViewModel(this IPagedList<WarrantyRequestStatus> models)
        {
            List<WarrantyRequestStatusViewModel> viewModels = new List<WarrantyRequestStatusViewModel>();
            models.ToList<WarrantyRequestStatus>().ForEach(delegate (WarrantyRequestStatus a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<WarrantyRequestStatusViewModel>(models.GetMetaData());
        }

        public static IList<WarrantyRequestStatusViewModel> ToViewModel(this IList<WarrantyRequestStatus> models)
        {
            List<WarrantyRequestStatusViewModel> viewModels = new List<WarrantyRequestStatusViewModel>();
            models.ToList<WarrantyRequestStatus>().ForEach(delegate (WarrantyRequestStatus a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels;
        }

    }
}

