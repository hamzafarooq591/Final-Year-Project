namespace NashWebApi.Services.BloodLab
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface IAppointmentOfferService
    {
        AppointmentOfferViewModel CreateAppointmentOffer(AppointmentOfferBindingModel model, int userId);
        bool DeleteAppointmentOffer(int AppointmentOfferId);
        AppointmentOfferViewModel GetAppointmentOfferByAppointmentOfferId(int AppointmentOfferId);
        NashPagedList<AppointmentOfferViewModel> GetAppointmentOffer(int rows, int pageNumber , int? BranchId = null);
        AppointmentOfferViewModel UpdateAppointmentOffer(AppointmentOfferBindingModel model, int userId);
        
    }
}

