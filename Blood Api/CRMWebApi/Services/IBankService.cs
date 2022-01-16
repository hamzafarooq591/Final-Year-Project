namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IBankService
    {
        BankViewModel CreateBank(BankBindingModel model, int userId);
        bool DeleteBank(int BankId);
        BankViewModel GetBankByBankId(int BankId);
        NashPagedList<BankViewModel> GetBank(int rows, int pageNumber , string SearchString = "");
        BankViewModel UpdateBank(BankBindingModel model, int userId);
    }
}

