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

    public static class ClearingAgentMapper
    {
        public static ClearingAgent ToEntity(this ClearingAgentBindingModel model, int userId, ClearingAgent original = null)
        {
            bool flag = original != null;
            ClearingAgent company = flag ? model.Map<ClearingAgentBindingModel, ClearingAgent>(original) : model.Map<ClearingAgentBindingModel, ClearingAgent>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<ClearingAgent>(userId);
            }
            return company.MapLastModifiedFields<ClearingAgent>(userId);
        }
        public static NashPagedList<ClearingAgentViewModel> ToViewModel(this IPagedList<ClearingAgent> models)
        {
            List<ClearingAgentViewModel> viewModels = new List<ClearingAgentViewModel>();
            models.ToList<ClearingAgent>().ForEach(delegate (ClearingAgent a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<ClearingAgentViewModel>(models.GetMetaData());
        }
        public static ClearingAgentViewModel ToViewModel(this ClearingAgent model)
        {
            return model.Map<ClearingAgent, ClearingAgentViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<ClearingAgent, ClearingAgentViewModel>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.ClearingAgentId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<ClearingAgentViewModel>(model);

        }
    }
}

