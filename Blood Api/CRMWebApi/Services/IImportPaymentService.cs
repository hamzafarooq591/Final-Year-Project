namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IImportPaymentService
    {
        ImportPaymentViewModel CreateImportPayment(ImportPaymentBindingModel model, int userId);
        bool DeleteImportPayment(int ImportPaymentId);
        ImportPaymentViewModel GetImportPaymentByImportPaymentId(int ImportPaymentId);
        NashPagedList<ImportPaymentViewModel> GetImportPayment(int rows, int pageNumber, int? PayToType);
        ImportPaymentViewModel UpdateImportPayment(ImportPaymentBindingModel model, int userId);
    }
}

