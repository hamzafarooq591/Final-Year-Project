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
    
    public class PageContentRepository : Repository<PageContent>, IPageContentRepository, IRepository<PageContent>
    {
        public PageContentRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<PageContent> Filter(int rows, int pageNumber)
        {
            var result = NashContext.PageContents
                .Include(x => x.StaticPage)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<PageContent>(pageNumber, rows);
        }
         
        public PageContentViewModel FindOneMapped(int PageContentId) =>
            this.FindOne(PageContentId).FirstOrDefault<PageContent>().ToViewModel();

        public IQueryable<PageContent> FindOne(int PageContentId)
        {
            return NashContext.PageContents
                .Include(x => x.StaticPage)
                .Where(x => x.Id == PageContentId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

