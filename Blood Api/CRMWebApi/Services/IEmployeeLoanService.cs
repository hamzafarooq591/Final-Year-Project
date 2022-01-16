namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeLoanService
    {
        EmployeeLoanViewModel CreateEmployeeLoan(EmployeeLoanBindingModel model, int userId);
        bool DeleteEmployeeLoan(int EmployeeLoanId);
        EmployeeLoanViewModel GetEmployeeLoanByEmployeeLoanId(int EmployeeLoanId);
        NashPagedList<EmployeeLoanViewModel> GetEmployeeLoan(int rows, int pageNumber);
        EmployeeLoanViewModel UpdateEmployeeLoan(EmployeeLoanBindingModel model, int userId);
    }
}

