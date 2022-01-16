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

    public class EmailTemplateTypeRepository : Repository<EmailTemplateType>, IEmailTemplateTypeRepository, IRepository<EmailTemplateType>
    {
        public EmailTemplateTypeRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<EmailTemplateType> Filter(int rows, int pageNumber)
        {

            return NashContext.EmailTemplateTypes
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<EmailTemplateType>(pageNumber, rows);
        }

        public IQueryable<EmailTemplateType> FindOne(int EmailTemplateTypeId)
        {

            return NashContext.EmailTemplateTypes
                .Where(x => x.IsDeleted == false && x.Id == EmailTemplateTypeId);
        }

        public EmailTemplateTypeViewModel FindOneMapped(int EmailTemplateTypeId) =>
            this.FindOne(EmailTemplateTypeId).FirstOrDefault<EmailTemplateType>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

