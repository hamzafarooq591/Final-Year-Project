namespace NashWebApi.Services.BloodLab
{
    using NashWebApi.BindingModels.BloodLab;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels.BloodLab;
    using System;
    using System.Collections.Generic;

    public interface IOfferService
    {
        OfferViewModel CreateOffer(OfferBindingModel model, int userId);
        bool DeleteOffer(int OfferId);
        OfferViewModel GetOfferByOfferId(int OfferId);
        NashPagedList<OfferViewModel> GetOffer(int rows, int pageNumber , int? BranchId = null);
        OfferViewModel UpdateOffer(OfferBindingModel model, int userId);
        
    }
}

