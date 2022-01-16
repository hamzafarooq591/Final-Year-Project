namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IBillToTypeService
    {
        BillToTypeViewModel CreateBillToType(BillToTypeBindingModel model, int userId);
        bool DeleteBillToType(int BillToTypeId);
        BillToTypeViewModel GetBillToTypeByBillToTypeId(int BillToTypeId);
        NashPagedList<BillToTypeViewModel> GetBillToType(int rows, int pageNumber );
        BillToTypeViewModel UpdateBillToType(BillToTypeBindingModel model, int userId);
    }
}

