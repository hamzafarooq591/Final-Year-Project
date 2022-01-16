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

    public static class FreightForwarderMapper
    {
        public static FreightForwarder ToEntity(this FreightForwarderBindingModel model, int userId, FreightForwarder original = null)
        {
            bool flag = original != null;
            FreightForwarder company = flag ? model.Map<FreightForwarderBindingModel, FreightForwarder>(original) : model.Map<FreightForwarderBindingModel, FreightForwarder>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<FreightForwarder>(userId);
            }
            return company.MapLastModifiedFields<FreightForwarder>(userId);
        }
        public static NashPagedList<FreightForwarderViewModel> ToViewModel(this IPagedList<FreightForwarder> models)
        {
            List<FreightForwarderViewModel> viewModels = new List<FreightForwarderViewModel>();
            models.ToList<FreightForwarder>().ForEach(delegate (FreightForwarder a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<FreightForwarderViewModel>(models.GetMetaData());
        }
        public static FreightForwarderViewModel ToViewModel(this FreightForwarder model)
        {
            return model.Map<FreightForwarder, FreightForwarderViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<FreightForwarder, FreightForwarderViewModel>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.FreightForwarderId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<FreightForwarderViewModel>(model);

        }
    }
}

