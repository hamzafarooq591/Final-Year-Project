namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INewsLetterSubscriberRepository : IRepository<NewsLetterSubscriber>
    {
        IPagedList<NewsLetterSubscriber> Filter(int rows, int pageNumber);
        IQueryable<NewsLetterSubscriber> FindOne(int NewsLetterSubscriberId);
        NewsLetterSubscriberViewModel FindOneMapped(int NewsLetterSubscriberId);
    }
}

