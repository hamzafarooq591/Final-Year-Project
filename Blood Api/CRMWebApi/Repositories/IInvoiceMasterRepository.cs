namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IInvoiceMasterRepository : IRepository<InvoiceMaster>
    {
        IPagedList<InvoiceMaster> Filter(int rows, int pageNumber, int? BillToType);
        IQueryable<InvoiceMaster> FindOne(int InvoiceMasterId);
        InvoiceMasterViewModel FindOneMapped(int InvoiceMasterId);
    }
}

