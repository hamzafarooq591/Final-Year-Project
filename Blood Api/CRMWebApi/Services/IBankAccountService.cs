namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IBankAccountService
    {
        BankAccountViewModel CreateBankAccount(BankAccountBindingModel model, int userId);
        bool DeleteBankAccount(int BankAccountId);
        BankAccountViewModel GetBankAccountByBankAccountId(int BankAccountId);
        NashPagedList<BankAccountViewModel> GetBankAccount(int rows, int pageNumber);
        BankAccountViewModel UpdateBankAccount(BankAccountBindingModel model, int userId);
    }
}

