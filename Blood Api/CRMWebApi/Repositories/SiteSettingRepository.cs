namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;

    public class SiteSettingRepository : Repository<SiteSetting>, ISiteSettingRepository, IRepository<SiteSetting>
    {
        public SiteSettingRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<SiteSetting> Filter(int rows, int pageNumber)
        {

            return NashContext.SiteSettings
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<SiteSetting>(pageNumber, rows);
        }

        public IQueryable<SiteSetting> FindOne(int SiteSettingId)
        {

            return NashContext.SiteSettings
                .Where(x => x.IsDeleted == false && x.Id == SiteSettingId);
        }

        public SiteSettingViewModel FindOneMapped(int SiteSettingId) =>
            this.FindOne(SiteSettingId).FirstOrDefault<SiteSetting>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

