namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IEmployeeBonusService
    {
        EmployeeBonusViewModel CreateEmployeeBonus(EmployeeBonusBindingModel model, int userId);
        bool DeleteEmployeeBonus(int EmployeeBonusId);
        EmployeeBonusViewModel GetEmployeeBonusByEmployeeBonusId(int EmployeeBonusId);
        NashPagedList<EmployeeBonusViewModel> GetEmployeeBonus(int rows, int pageNumber , string SearchString = "");
        EmployeeBonusViewModel UpdateEmployeeBonus(EmployeeBonusBindingModel model, int userId);
    }
}

