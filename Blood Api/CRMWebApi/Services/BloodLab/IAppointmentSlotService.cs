namespace NashWebApi.Services.BloodLab
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface IAppointmentSlotService
    {
        AppointmentSlotViewModel CreateAppointmentSlot(AppointmentSlotBindingModel model, int userId);
        bool DeleteAppointmentSlot(int AppointmentSlotId);
        AppointmentSlotViewModel GetAppointmentSlotByAppointmentSlotId(int AppointmentSlotId);
        NashPagedList<AppointmentSlotViewModel> GetAppointmentSlot(int rows, int pageNumber , int? BranchId = null);
        AppointmentSlotViewModel UpdateAppointmentSlot(AppointmentSlotBindingModel model, int userId);
        
    }
}

