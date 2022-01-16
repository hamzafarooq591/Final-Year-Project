namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IAccountService
    {
        AccountViewModel CreateAccount(AccountBindingModel model, int userId);
        bool DeleteAccount(int AccountId);
        AccountViewModel GetAccountByAccountId(int AccountId);
        NashPagedList<AccountViewModel> GetAccount(int rows, int pageNumber , int? BranchId = null);
        AccountViewModel UpdateAccount(AccountBindingModel model, int userId);
        NashPagedList<TrailBalanceViewModel> GetTrailBalance(int rows, int pageNumber, string SearchString = "");
        NashPagedList<AccountViewModel> GetParentAccount(int rows, int pageNumber);
        ProfitLossReportViewModel GetProfitAndLoss();
    }
}

