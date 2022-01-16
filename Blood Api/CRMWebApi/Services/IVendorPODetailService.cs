namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IVendorPODetailService
    {
        VendorPODetailViewModel CreateVendorPODetail(VendorPODetailBindingModel model, int userId);
        bool DeleteVendorPODetail(int VendorPODetailId);
        VendorPODetailViewModel GetVendorPODetailByVendorPODetailId(int VendorPODetailId);
        NashPagedList<VendorPODetailViewModel> GetVendorPODetail(int rows, int pageNumber );
        VendorPODetailViewModel UpdateVendorPODetail(VendorPODetailBindingModel model, int userId);
    }
}

