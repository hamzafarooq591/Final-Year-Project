namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IInvoiceSummaryService
    {
        InvoiceSummaryViewModel CreateInvoiceSummary(InvoiceSummaryBindingModel model, int userId);
        bool DeleteInvoiceSummary(int InvoiceSummaryId);
        InvoiceSummaryViewModel GetInvoiceSummaryByInvoiceSummaryId(int InvoiceSummaryId);
        NashPagedList<InvoiceSummaryViewModel> GetInvoiceSummary(int rows, int pageNumber );
        InvoiceSummaryViewModel UpdateInvoiceSummary(InvoiceSummaryBindingModel model, int userId);
    }
}

