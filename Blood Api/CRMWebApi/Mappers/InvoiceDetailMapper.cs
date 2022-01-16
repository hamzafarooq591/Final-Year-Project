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

    public static class InvoiceDetailMapper
    {
        public static InvoiceDetail ToEntity(this InvoiceDetailBindingModel model, int userId, InvoiceDetail original = null)
        {
            bool flag = original != null;
            InvoiceDetail company = flag ? model.Map<InvoiceDetailBindingModel, InvoiceDetail>(original) : model.Map<InvoiceDetailBindingModel, InvoiceDetail>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<InvoiceDetail>(userId);
            }
            return company.MapLastModifiedFields<InvoiceDetail>(userId);
        }
        public static NashPagedList<InvoiceDetailViewModel> ToViewModel(this IPagedList<InvoiceDetail> models)
        {
            List<InvoiceDetailViewModel> viewModels = new List<InvoiceDetailViewModel>();
            models.ToList<InvoiceDetail>().ForEach(delegate (InvoiceDetail a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<InvoiceDetailViewModel>(models.GetMetaData());
        }
        public static InvoiceDetailViewModel ToViewModel(this InvoiceDetail model)
        {
            return model.Map<InvoiceDetail, InvoiceDetailViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<InvoiceDetail, InvoiceDetailViewModel>()
                .ForMember(x => x.InvoiceMasterId, y => y.MapFrom(x => x.InvoiceMaster.Id))
                .ForMember(x => x.InvoiceDetailId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<InvoiceDetailViewModel>(model);

        }
    }
}

