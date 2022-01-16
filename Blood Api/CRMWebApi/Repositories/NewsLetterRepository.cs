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

    public class NewsLetterRepository : Repository<NewsLetter>, INewsLetterRepository, IRepository<NewsLetter>
    {
        public NewsLetterRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<NewsLetter> Filter(int rows, int pageNumber)
        {

            return NashContext.NewsLetters
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<NewsLetter>(pageNumber, rows);
        }

        public IQueryable<NewsLetter> FindOne(int NewsLetterId)
        {

            return NashContext.NewsLetters
                .Where(x => x.IsDeleted == false && x.Id == NewsLetterId);
        }

        public NewsLetterViewModel FindOneMapped(int NewsLetterId) =>
            this.FindOne(NewsLetterId).FirstOrDefault<NewsLetter>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

