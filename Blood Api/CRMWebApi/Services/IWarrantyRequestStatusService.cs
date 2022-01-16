namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IWarrantyRequestStatusService
    {
        WarrantyRequestStatusViewModel CreateWarrantyRequestStatus(WarrantyRequestStatusBindingModel model, int userId);
        bool DeleteWarrantyRequestStatus(int WarrantyRequestStatusId);
        WarrantyRequestStatusViewModel GetWarrantyRequestStatusByWarrantyRequestStatusId(int WarrantyRequestStatusId);
        NashPagedList<WarrantyRequestStatusViewModel> GetWarrantyRequestStatus(int rows, int pageNumber );
        WarrantyRequestStatusViewModel UpdateWarrantyRequestStatus(WarrantyRequestStatusBindingModel model, int userId);
    }
}

