namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPerformaInvoiceService
    {
        PerformaInvoiceViewModel CreatePerformaInvoice(PerformaInvoiceBindingModel model, int userId);
        bool DeletePerformaInvoice(int PerformaInvoiceId);
        PerformaInvoiceViewModel GetPerformaInvoiceByPerformaInvoiceId(int PerformaInvoiceId);
        NashPagedList<PerformaInvoiceViewModel> GetPerformaInvoice(int rows, int pageNumber);
        PerformaInvoiceViewModel UpdatePerformaInvoice(PerformaInvoiceBindingModel model, int userId);
    }
}

