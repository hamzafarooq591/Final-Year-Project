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

    public static class PerformaInvoiceMapper
    {
        public static PerformaInvoice ToEntity(this PerformaInvoiceBindingModel model, int userId, PerformaInvoice original = null)
        {
            bool flag = original != null;
            PerformaInvoice company = flag ? model.Map<PerformaInvoiceBindingModel, PerformaInvoice>(original) : model.Map<PerformaInvoiceBindingModel, PerformaInvoice>();
            if (!flag)
            {
                return company.MapCreatedAndLastModifiedFields<PerformaInvoice>(userId);
            }
            return company.MapLastModifiedFields<PerformaInvoice>(userId);
        }
        public static NashPagedList<PerformaInvoiceViewModel> ToViewModel(this IPagedList<PerformaInvoice> models)
        {
            List<PerformaInvoiceViewModel> viewModels = new List<PerformaInvoiceViewModel>();
            models.ToList<PerformaInvoice>().ForEach(delegate (PerformaInvoice a) {
                viewModels.Add(a.ToViewModel());
            });
            return viewModels.ToNashPagedList<PerformaInvoiceViewModel>(models.GetMetaData());
        }
        public static PerformaInvoiceViewModel ToViewModel(this PerformaInvoice model)
        {
            return model.Map<PerformaInvoice, PerformaInvoiceViewModel>(delegate (IMapperConfigurationExpression cfg) {
                cfg.CreateMap<PerformaInvoice, PerformaInvoiceViewModel>()
                .ForMember(x => x.PerformaInvoiceId, y => y.MapFrom(x => x.Id));
            }).MapAuditableFields<PerformaInvoiceViewModel>(model);

        }
    }
}

