namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ICourierCompanyService
    {
        CourierCompanyViewModel CreateCourierCompany(CourierCompanyBindingModel model, int userId);
        bool DeleteCourierCompany(int CourierCompanyId);
        CourierCompanyViewModel GetCourierCompanyByCourierCompanyId(int CourierCompanyId);
        NashPagedList<CourierCompanyViewModel> GetCourierCompany(int rows, int pageNumber );
        CourierCompanyViewModel UpdateCourierCompany(CourierCompanyBindingModel model, int userId);
    }
}

