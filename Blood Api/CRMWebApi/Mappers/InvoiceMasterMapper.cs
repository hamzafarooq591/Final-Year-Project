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

    public static class InvoiceMasterMapper
    {
        public static InvoiceMaster ToEntity(this InvoiceMasterBindingModel model, int userId, InvoiceMaster original = null)
        {
            bool flag = original != null;
            InvoiceMaster company = flag ? model.Map<InvoiceMasterBindingModel, InvoiceMaster>(original) : model.Map<InvoiceMasterBindingModel, InvoiceMaster>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<InvoiceMaster>(userId);
            }
            return company.MapLastModifiedFields<InvoiceMaster>(userId);
        }
        public static NashPagedList<InvoiceMasterViewModel> ToViewModel(this IPagedList<InvoiceMaster> models)
        {
            List<InvoiceMasterViewModel> viewModels = new List<InvoiceMasterViewModel>();
            models.ToList<InvoiceMaster>().ForEach(delegate (InvoiceMaster a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<InvoiceMasterViewModel>(models.GetMetaData());
        }
        public static InvoiceMasterViewModel ToViewModel(this InvoiceMaster model)
        {
            return model.Map<InvoiceMaster, InvoiceMasterViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<InvoiceMaster, InvoiceMasterViewModel>()
                .ForMember(x => x.BillToTypeId, y => y.MapFrom(x => x.BillToType.Id))
                .ForMember(x => x.BillToTypeName, y => y.MapFrom(x => x.BillToType.Title))
                .ForMember(x => x.ImageUploadId, y => y.MapFrom(x => x.ImageUpload.Id))
                .ForMember(x => x.ImageUploadURL, y => y.MapFrom(x => x.ImageUpload.fileUrl))
                .ForMember(x => x.CompanyId, y => y.MapFrom(x => x.Company.Id))
                .ForMember(x => x.CompanyName, y => y.MapFrom(x => x.Company.Name))
                .ForMember(x => x.InvoiceMasterId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<InvoiceMasterViewModel>(model);

        }
    }
}

