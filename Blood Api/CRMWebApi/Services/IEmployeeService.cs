namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeService
    {
        EmployeeViewModel CreateEmployee(EmployeeBindingModel model, int userId);
        bool DeleteEmployee(int EmployeeId);
        EmployeeViewModel GetEmployeeByEmployeeId(int EmployeeId);
        NashPagedList<EmployeeViewModel> GetEmployee(int rows, int pageNumber , string SearchString = "");
        EmployeeViewModel UpdateEmployee(EmployeeBindingModel model, int userId);
    }
}

