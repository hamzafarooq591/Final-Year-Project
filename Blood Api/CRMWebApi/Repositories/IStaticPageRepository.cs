namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IStaticPageRepository : IRepository<StaticPage>
    {
        IPagedList<StaticPage> Filter(int rows, int pageNumber);
        IQueryable<StaticPage> FindOne(int StaticPageId);
        StaticPageViewModel FindOneMapped(int StaticPageId);
    }
}

