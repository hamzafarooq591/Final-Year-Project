namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPerformaInvoiceRepository : IRepository<PerformaInvoice>
    {
        IPagedList<PerformaInvoice> Filter(int rows, int pageNumber);
        IQueryable<PerformaInvoice> FindOne(int PerformaInvoiceId);
        PerformaInvoiceViewModel FindOneMapped(int PerformaInvoiceId);
    }
}

