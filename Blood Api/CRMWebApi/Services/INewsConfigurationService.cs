namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface INewsConfigurationService
    {
        NewsConfigurationViewModel CreateNewsConfiguration(NewsConfigurationBindingModel model, int userId);
        bool DeleteNewsConfiguration(int NewsConfigurationId);
        NewsConfigurationViewModel GetNewsConfigurationByNewsConfigurationId(int NewsConfigurationId);
        NashPagedList<NewsConfigurationViewModel> GetNewsConfiguration(int rows, int pageNumber );
        NewsConfigurationViewModel UpdateNewsConfiguration(NewsConfigurationBindingModel model, int userId);
    }
}

