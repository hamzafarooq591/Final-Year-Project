namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IInvoiceSummaryRepository : IRepository<InvoiceSummary>
    {
        IPagedList<InvoiceSummary> Filter(int rows, int pageNumber);
        IQueryable<InvoiceSummary> FindOne(int InvoiceSummaryId);
        InvoiceSummaryViewModel FindOneMapped(int InvoiceSummaryId);
    }
}

