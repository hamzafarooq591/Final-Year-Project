namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INewsLetterTemplateRepository : IRepository<NewsLetterTemplate>
    {
        IPagedList<NewsLetterTemplate> Filter(int rows, int pageNumber);
        IQueryable<NewsLetterTemplate> FindOne(int NewsLetterTemplateId);
        NewsLetterTemplateViewModel FindOneMapped(int NewsLetterTemplateId);
    }
}

