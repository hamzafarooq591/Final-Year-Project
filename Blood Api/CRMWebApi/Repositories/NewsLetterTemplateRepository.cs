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

    public class NewsLetterTemplateRepository : Repository<NewsLetterTemplate>, INewsLetterTemplateRepository, IRepository<NewsLetterTemplate>
    {
        public NewsLetterTemplateRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NewsLetterTemplate> Filter(int rows, int pageNumber)
        {

            return NashContext.NewsLetterTemplates
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<NewsLetterTemplate>(pageNumber, rows);
        }

        public IQueryable<NewsLetterTemplate> FindOne(int NewsLetterTemplateId)
        {

            return NashContext.NewsLetterTemplates
                .Where(x => x.IsDeleted == false && x.Id == NewsLetterTemplateId);
        }

        public NewsLetterTemplateViewModel FindOneMapped(int NewsLetterTemplateId) =>
            this.FindOne(NewsLetterTemplateId).FirstOrDefault<NewsLetterTemplate>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

