namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IAccountsHeadService
    {
        AccountsHeadViewModel CreateAccountsHead(AccountsHeadBindingModel model, int userId);
        bool DeleteAccountsHead(int AccountsHeadId);
        AccountsHeadViewModel GetAccountsHeadByAccountsHeadId(int AccountsHeadId);
        NashPagedList<AccountsHeadViewModel> GetAccountsHead(int rows, int pageNumber , string SearchString = "");
        AccountsHeadViewModel UpdateAccountsHead(AccountsHeadBindingModel model, int userId);
    }
}

