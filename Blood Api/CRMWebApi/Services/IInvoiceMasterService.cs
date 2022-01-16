namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IInvoiceMasterService
    {
        InvoiceMasterViewModel CreateInvoiceMaster(InvoiceMasterBindingModel model, int userId);
        bool DeleteInvoiceMaster(int InvoiceMasterId);
        InvoiceMasterViewModel GetInvoiceMasterByInvoiceMasterId(int InvoiceMasterId);
        NashPagedList<InvoiceMasterViewModel> GetInvoiceMaster(int rows, int pageNumber, int? BillToType);
        InvoiceMasterViewModel UpdateInvoiceMaster(InvoiceMasterBindingModel model, int userId);
    }
}

