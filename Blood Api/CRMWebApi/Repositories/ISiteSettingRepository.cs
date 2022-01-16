namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface ISiteSettingRepository : IRepository<SiteSetting>
    {
        IPagedList<SiteSetting> Filter(int rows, int pageNumber);
        IQueryable<SiteSetting> FindOne(int SiteSettingId);
        SiteSettingViewModel FindOneMapped(int SiteSettingId);
    }
}

