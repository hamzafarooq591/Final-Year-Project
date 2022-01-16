
namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ISmsTypeService
    {
        SmsTypeViewModel CreateSmsType(SmsTypeBindingModel model, int userId);
        bool DeleteSmsType(int SmsTypeId);
        SmsTypeViewModel GetSmsTypeBySmsTypeId(int SmsTypeId);
        NashPagedList<SmsTypeViewModel> GetSmsType(int rows, int pageNumber );
        SmsTypeViewModel UpdateSmsType(SmsTypeBindingModel model, int userId);
    }
}

