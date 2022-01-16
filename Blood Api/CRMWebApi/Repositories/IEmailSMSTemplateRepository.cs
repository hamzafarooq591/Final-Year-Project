namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IEmailSMSTemplateRepository : IRepository<EmailSMSTemplate>
    {
        IPagedList<EmailSMSTemplate> Filter(int rows, int pageNumber);
        IQueryable<EmailSMSTemplate> FindOne(int EmailSMSTemplateId);
        EmailSMSTemplateViewModel FindOneMapped(int EmailSMSTemplateId);
    }
}

