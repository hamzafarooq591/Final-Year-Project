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

    public class NewsConfigurationRepository : Repository<NewsConfiguration>, INewsConfigurationRepository, IRepository<NewsConfiguration>
    {
        public NewsConfigurationRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NewsConfiguration> Filter(int rows, int pageNumber)
        {

            return NashContext.NewsConfigurations
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<NewsConfiguration>(pageNumber, rows);
        }

        public IQueryable<NewsConfiguration> FindOne(int NewsConfigurationId)
        {

            return NashContext.NewsConfigurations
                .Where(x => x.IsDeleted == false && x.Id == NewsConfigurationId);
        }

        public NewsConfigurationViewModel FindOneMapped(int NewsConfigurationId) =>
            this.FindOne(NewsConfigurationId).FirstOrDefault<NewsConfiguration>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

