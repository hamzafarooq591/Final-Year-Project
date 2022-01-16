namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICompanyService
    {
        CompanyViewModel CreateCompany(CompanyBindingModel model, int userId);
        bool DeleteCompany(int companyId);
        CompanyViewModel GetCompanyByCompanyId(int companyId);
        NashPagedList<CompanyViewModel> GetCompany(int rows, int pageNumber , string SearchString = "");
        CompanyViewModel UpdateCompany(CompanyBindingModel model, int userId);
    }
}

