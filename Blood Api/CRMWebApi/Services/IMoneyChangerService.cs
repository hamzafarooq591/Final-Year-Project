namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IMoneyChangerService
    {
        MoneyChangerViewModel CreateMoneyChanger(MoneyChangerBindingModel model, int userId);
        bool DeleteMoneyChanger(int MoneyChangerId);
        MoneyChangerViewModel GetMoneyChangerByMoneyChangerId(int MoneyChangerId);
        NashPagedList<MoneyChangerViewModel> GetMoneyChanger(int rows, int pageNumber);
        MoneyChangerViewModel UpdateMoneyChanger(MoneyChangerBindingModel model, int userId);
    }
}

