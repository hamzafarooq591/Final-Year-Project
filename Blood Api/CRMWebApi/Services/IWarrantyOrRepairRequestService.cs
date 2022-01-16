namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IWarrantyOrRepairRequestService
    {
        WarrantyOrRepairRequestViewModel CreateWarrantyOrRepairRequest(WarrantyOrRepairRequestBindingModel model, int userId);
        bool DeleteWarrantyOrRepairRequest(int WarrantyOrRepairRequestId);
        WarrantyOrRepairRequestViewModel GetWarrantyOrRepairRequestByWarrantyOrRepairRequestId(int WarrantyOrRepairRequestId);
        NashPagedList<WarrantyOrRepairRequestViewModel> GetWarrantyOrRepairRequest(int rows, int pageNumber);
        WarrantyOrRepairRequestViewModel UpdateWarrantyOrRepairRequest(WarrantyOrRepairRequestBindingModel model, int userId);
    }
}

