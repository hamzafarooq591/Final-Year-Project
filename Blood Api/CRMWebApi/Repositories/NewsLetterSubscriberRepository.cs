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
    
    public class NewsLetterSubscriberRepository : Repository<NewsLetterSubscriber>, INewsLetterSubscriberRepository, IRepository<NewsLetterSubscriber>
    {
        public NewsLetterSubscriberRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<NewsLetterSubscriber> Filter(int rows, int pageNumber)
        {
            var result = NashContext.NewsLetterSubscribers
                .Include(x => x.NashUser)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<NewsLetterSubscriber>(pageNumber, rows);
        }
         
        public NewsLetterSubscriberViewModel FindOneMapped(int NewsLetterSubscriberId) =>
            this.FindOne(NewsLetterSubscriberId).FirstOrDefault<NewsLetterSubscriber>().ToViewModel();

        public IQueryable<NewsLetterSubscriber> FindOne(int NewsLetterSubscriberId)
        {
            return NashContext.NewsLetterSubscribers
                .Include(x => x.NashUser)
                .Where(x => x.Id == NewsLetterSubscriberId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

