namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPayslipService
    {
        PayslipViewModel CreatePayslip(PayslipBindingModel model, int userId);
        bool DeletePayslip(int PayslipId);
        PayslipViewModel GetPayslipByPayslipId(int PayslipId);
        NashPagedList<PayslipViewModel> GetPayslip(int rows, int pageNumber);
        PayslipViewModel UpdatePayslip(PayslipBindingModel model, int userId);
    }
}

