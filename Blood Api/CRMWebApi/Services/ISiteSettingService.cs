
namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface ISiteSettingService
    {
        SiteSettingViewModel CreateSiteSetting(SiteSettingBindingModel model, int userId);
        bool DeleteSiteSetting(int SiteSettingId);
        SiteSettingViewModel GetSiteSettingBySiteSettingId(int SiteSettingId);
        NashPagedList<SiteSettingViewModel> GetSiteSetting(int rows, int pageNumber );
        SiteSettingViewModel UpdateSiteSetting(SiteSettingBindingModel model, int userId);
    }
}

