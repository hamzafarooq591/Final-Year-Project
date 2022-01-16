namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INewsLetterRepository : IRepository<NewsLetter>
    {
        IPagedList<NewsLetter> Filter(int rows, int pageNumber);
        IQueryable<NewsLetter> FindOne(int NewsLetterId);
        NewsLetterViewModel FindOneMapped(int NewsLetterId);
    }
}

