namespace NashWebApi.Services.BloodLab
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface IAppointmentService
    {
        AppointmentViewModel CreateAppointment(AppointmentBindingModel model, int userId);
        bool DeleteAppointment(int AppointmentId);
        AppointmentViewModel GetAppointmentByAppointmentId(int AppointmentId);
        NashPagedList<AppointmentViewModel> GetAppointment(int rows, int pageNumber , int? BranchId = null);
        AppointmentViewModel UpdateAppointment(AppointmentBindingModel model, int userId);
        List<AppointmentViewModel> GetAppointmentByPatientId(int? PatientId);
























    }
}

