namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IOtherPaymentService
    {
        OtherPaymentViewModel CreateOtherPayment(OtherPaymentBindingModel model, int userId);
        bool DeleteOtherPayment(int OtherPaymentId);
        OtherPaymentViewModel GetOtherPaymentByOtherPaymentId(int OtherPaymentId);
        NashPagedList<OtherPaymentViewModel> GetOtherPayment(int rows, int pageNumber);
        OtherPaymentViewModel UpdateOtherPayment(OtherPaymentBindingModel model, int userId);
    }
}

