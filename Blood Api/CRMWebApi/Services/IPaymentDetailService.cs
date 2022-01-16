namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPaymentDetailService
    {
        PaymentDetailViewModel CreatePaymentDetail(PaymentDetailBindingModel model, int userId);
        bool DeletePaymentDetail(int PaymentDetailId);
        PaymentDetailViewModel GetPaymentDetailByPaymentDetailId(int PaymentDetailId);
        NashPagedList<PaymentDetailViewModel> GetPaymentDetail(int rows, int pageNumber);
        PaymentDetailViewModel UpdatePaymentDetail(PaymentDetailBindingModel model, int userId);
    }
}

