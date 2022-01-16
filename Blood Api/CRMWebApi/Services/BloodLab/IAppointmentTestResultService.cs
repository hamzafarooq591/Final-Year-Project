namespace NashWebApi.Services.BloodLab
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface IAppointmentTestResultService
    {
        AppointmentTestResultViewModel CreateAppointmentTestResult(AppointmentTestResultBindingModel model, int userId);
        bool DeleteAppointmentTestResult(int AppointmentTestResultResultId);
        AppointmentTestResultViewModel GetAppointmentTestResultByAppointmentTestResultId(int AppointmentTestResultId);
        NashPagedList<AppointmentTestResultViewModel> GetAppointmentTestResult(int rows, int pageNumber , int? BranchId = null);
        AppointmentTestResultViewModel UpdateAppointmentTestResult(AppointmentTestResultBindingModel model, int userId);
        List<string> GetAppointmentTestResultByAppointmentId(int AppointmentId);

    }
}

