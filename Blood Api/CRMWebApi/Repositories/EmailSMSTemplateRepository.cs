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
    
    public class EmailSMSTemplateRepository : Repository<EmailSMSTemplate>, IEmailSMSTemplateRepository, IRepository<EmailSMSTemplate>
    {
        public EmailSMSTemplateRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<EmailSMSTemplate> Filter(int rows, int pageNumber)
        {
            var result = NashContext.EmailSMSTemplates
                .Include(x => x.EmailTemplateType)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<EmailSMSTemplate>(pageNumber, rows);
        }
         
        public EmailSMSTemplateViewModel FindOneMapped(int EmailSMSTemplateId) =>
            this.FindOne(EmailSMSTemplateId).FirstOrDefault<EmailSMSTemplate>().ToViewModel();

        public IQueryable<EmailSMSTemplate> FindOne(int EmailSMSTemplateId)
        {
            return NashContext.EmailSMSTemplates
                .Include(x => x.EmailTemplateType)
                .Where(x => x.Id == EmailSMSTemplateId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

