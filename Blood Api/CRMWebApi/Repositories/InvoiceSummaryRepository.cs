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

    public class InvoiceSummaryRepository : Repository<InvoiceSummary>, IInvoiceSummaryRepository, IRepository<InvoiceSummary>
    {
        public InvoiceSummaryRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<InvoiceSummary> Filter(int rows, int pageNumber)
        {

            return NashContext.InvoiceSummaries
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<InvoiceSummary>(pageNumber, rows);
        }

        public IQueryable<InvoiceSummary> FindOne(int InvoiceSummaryId)
        {

            return NashContext.InvoiceSummaries
                .Where(x => x.IsDeleted == false && x.Id == InvoiceSummaryId);
        }

        public InvoiceSummaryViewModel FindOneMapped(int InvoiceSummaryId) =>
            this.FindOne(InvoiceSummaryId).FirstOrDefault<InvoiceSummary>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

