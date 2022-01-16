namespace NashWebApi.Services.BloodLab
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface IAppointmentTestService
    {
        AppointmentTestViewModel CreateAppointmentTest(AppointmentTestBindingModel model, int userId);
        bool DeleteAppointmentTest(int AppointmenTestId);
        AppointmentTestViewModel GetAppointmentTestByAppointmentTestId(int AppointmenTestId);
        NashPagedList<AppointmentTestViewModel> GetAppointmentTest(int rows, int pageNumber , int? BranchId = null);
        AppointmentTestViewModel UpdateAppointmentTest(AppointmentTestBindingModel model, int userId);
        
    }
}

