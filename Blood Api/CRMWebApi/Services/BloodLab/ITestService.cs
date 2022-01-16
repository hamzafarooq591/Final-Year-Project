namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface ITestService
    {
        TestViewModel CreateTest(TestBindingModel model, int userId);
        bool DeleteTest(int TestId);
        TestViewModel GetTestByTestId(int TestId);
        NashPagedList<TestViewModel> GetTest(int rows, int pageNumber , int? BranchId = null);
        TestViewModel UpdateTest(TestBindingModel model, int userId);
        
    }
}

