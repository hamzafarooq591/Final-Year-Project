namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IInvoiceDetailService
    {
        InvoiceDetailViewModel CreateInvoiceDetail(InvoiceDetailBindingModel model, int userId);
        bool DeleteInvoiceDetail(int InvoiceDetailId);
        InvoiceDetailViewModel GetInvoiceDetailByInvoiceDetailId(int InvoiceDetailId);
        NashPagedList<InvoiceDetailViewModel> GetInvoiceDetail(int rows, int pageNumber);
        InvoiceDetailViewModel UpdateInvoiceDetail(InvoiceDetailBindingModel model, int userId);
    }
}

