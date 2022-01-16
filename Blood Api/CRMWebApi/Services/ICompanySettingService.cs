namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICompanySettingService
    {
        CompanySettingViewModel CreateCompanySetting(CompanySettingBindingModel model, int userId);
        bool DeleteCompanySetting(int CompanySettingId);
        CompanySettingViewModel GetCompanySettingByCompanySettingId(int CompanySettingId);
        NashPagedList<CompanySettingViewModel> GetCompanySetting(int rows, int pageNumber);
        CompanySettingViewModel UpdateCompanySetting(CompanySettingBindingModel model, int userId);
    }
}

