namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INewsListRepository : IRepository<NewsList>
    {
        IPagedList<NewsList> Filter(int rows, int pageNumber);
        IQueryable<NewsList> FindOne(int NewsListId);
        NewsListViewModel FindOneMapped(int NewsListId);
    }
}

