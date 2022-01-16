namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IVendorService
    {
        VendorViewModel CreateVendor(VendorBindingModel model, int userId);
        bool DeleteVendor(int VendorId);
        VendorViewModel GetVendorByVendorId(int VendorId);
        NashPagedList<VendorViewModel> GetVendor(int rows, int pageNumber);
        VendorViewModel UpdateVendor(VendorBindingModel model, int userId);
    }
}

