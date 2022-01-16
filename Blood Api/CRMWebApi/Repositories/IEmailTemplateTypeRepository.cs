namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IEmailTemplateTypeRepository : IRepository<EmailTemplateType>
    {
        IPagedList<EmailTemplateType> Filter(int rows, int pageNumber);
        IQueryable<EmailTemplateType> FindOne(int EmailTemplateTypeId);
        EmailTemplateTypeViewModel FindOneMapped(int EmailTemplateTypeId);
    }
}

