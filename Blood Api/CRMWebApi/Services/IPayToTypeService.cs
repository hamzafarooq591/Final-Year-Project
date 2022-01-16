namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPayToTypeService
    {
        PayToTypeViewModel CreatePayToType(PayToTypeBindingModel model, int userId);
        bool DeletePayToType(int PayToTypeId);
        PayToTypeViewModel GetPayToTypeByPayToTypeId(int PayToTypeId);
        NashPagedList<PayToTypeViewModel> GetPayToType(int rows, int pageNumber );
        PayToTypeViewModel UpdatePayToType(PayToTypeBindingModel model, int userId);
    }
}

