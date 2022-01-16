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

    public class NewsListRepository : Repository<NewsList>, INewsListRepository, IRepository<NewsList>
    {
        public NewsListRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NewsList> Filter(int rows, int pageNumber)
        {

            return NashContext.NewsLists
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<NewsList>(pageNumber, rows);
        }

        public IQueryable<NewsList> FindOne(int NewsListId)
        {

            return NashContext.NewsLists
                .Where(x => x.IsDeleted == false && x.Id == NewsListId);
        }

        public NewsListViewModel FindOneMapped(int NewsListId) =>
            this.FindOne(NewsListId).FirstOrDefault<NewsList>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

