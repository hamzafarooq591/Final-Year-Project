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

    public static class VendorMapper
    {
        public static Vendor ToEntity(this VendorBindingModel model, int userId, Vendor original = null)
        {
            bool flag = original != null;
            Vendor company = flag ? model.Map<VendorBindingModel, Vendor>(original) : model.Map<VendorBindingModel, Vendor>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<Vendor>(userId);
            }
            return company.MapLastModifiedFields<Vendor>(userId);
        }
        public static NashPagedList<VendorViewModel> ToViewModel(this IPagedList<Vendor> models)
        {
            List<VendorViewModel> viewModels = new List<VendorViewModel>();
            models.ToList<Vendor>().ForEach(delegate (Vendor a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<VendorViewModel>(models.GetMetaData());
        }
        public static VendorViewModel ToViewModel(this Vendor model)
        {
            return model.Map<Vendor, VendorViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<Vendor, VendorViewModel>()
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.VendorId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<VendorViewModel>(model);

        }
    }
}

