namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPageContentRepository : IRepository<PageContent>
    {
        IPagedList<PageContent> Filter(int rows, int pageNumber);
        IQueryable<PageContent> FindOne(int PageContentId);
        PageContentViewModel FindOneMapped(int PageContentId);
    }
}

