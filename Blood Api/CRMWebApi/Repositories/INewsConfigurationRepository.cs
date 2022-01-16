namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INewsConfigurationRepository : IRepository<NewsConfiguration>
    {
        IPagedList<NewsConfiguration> Filter(int rows, int pageNumber);
        IQueryable<NewsConfiguration> FindOne(int NewsConfigurationId);
        NewsConfigurationViewModel FindOneMapped(int NewsConfigurationId);
    }
}

