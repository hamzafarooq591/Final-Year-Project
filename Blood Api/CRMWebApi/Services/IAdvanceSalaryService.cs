namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IAdvanceSalaryService
    {
        AdvanceSalaryViewModel CreateAdvanceSalary(AdvanceSalaryBindingModel model, int userId);
        bool DeleteAdvanceSalary(int AdvanceSalaryId);
        AdvanceSalaryViewModel GetAdvanceSalaryByAdvanceSalaryId(int AdvanceSalaryId);
        NashPagedList<AdvanceSalaryViewModel> GetAdvanceSalary(int rows, int pageNumber );
        AdvanceSalaryViewModel UpdateAdvanceSalary(AdvanceSalaryBindingModel model, int userId);
    }
}

