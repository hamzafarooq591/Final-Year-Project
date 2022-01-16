namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ISmsConfigurationService
    {
        SmsConfigurationViewModel CreateSmsConfiguration(SmsConfigurationBindingModel model, int userId);
        bool DeleteSmsConfiguration(int SmsConfigurationId);
        SmsConfigurationViewModel GetSmsConfigurationBySmsConfigurationId(int SmsConfigurationId);
        NashPagedList<SmsConfigurationViewModel> GetSmsConfiguration(int rows, int pageNumber);
        SmsConfigurationViewModel UpdateSmsConfiguration(SmsConfigurationBindingModel model, int userId);
    }
}

