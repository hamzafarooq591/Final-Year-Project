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

    public class StaticPageRepository : Repository<StaticPage>, IStaticPageRepository, IRepository<StaticPage>
    {
        public StaticPageRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<StaticPage> Filter(int rows, int pageNumber)
        {

            return NashContext.StaticPages
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<StaticPage>(pageNumber, rows);
        }

        public IQueryable<StaticPage> FindOne(int StaticPageId)
        {

            return NashContext.StaticPages
                .Where(x => x.IsDeleted == false && x.Id == StaticPageId);
        }

        public StaticPageViewModel FindOneMapped(int StaticPageId) =>
            this.FindOne(StaticPageId).FirstOrDefault<StaticPage>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

