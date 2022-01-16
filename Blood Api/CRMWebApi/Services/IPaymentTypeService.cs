namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPaymentTypeService
    {
        PaymentTypeViewModel CreatePaymentType(PaymentTypeBindingModel model, int userId);
        bool DeletePaymentType(int PaymentTypeId);
        PaymentTypeViewModel GetPaymentTypeByPaymentTypeId(int PaymentTypeId);
        NashPagedList<PaymentTypeViewModel> GetPaymentType(int rows, int pageNumber );
        PaymentTypeViewModel UpdatePaymentType(PaymentTypeBindingModel model, int userId);
    }
}

