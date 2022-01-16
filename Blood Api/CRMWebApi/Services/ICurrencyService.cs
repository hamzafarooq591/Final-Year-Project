namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICurrencyService
    {
        CurrencyViewModel CreateCurrency(CurrencyBindingModel model, int userId);
        bool DeleteCurrency(int CurrencyId);
        CurrencyViewModel GetCurrencyByCurrencyId(int CurrencyId);
        NashPagedList<CurrencyViewModel> GetCurrency(int rows, int pageNumber );
        CurrencyViewModel UpdateCurrency(CurrencyBindingModel model, int userId);
    }
}

