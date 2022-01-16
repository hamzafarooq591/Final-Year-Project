namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IInvoiceDetailRepository : IRepository<InvoiceDetail>
    {
        IPagedList<InvoiceDetail> Filter(int rows, int pageNumber);
        IQueryable<InvoiceDetail> FindOne(int InvoiceDetailId);
        InvoiceDetailViewModel FindOneMapped(int InvoiceDetailId);
    }
}

