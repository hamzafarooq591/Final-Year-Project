namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IImportPaymentRepository : IRepository<ImportPayment>
    {
        IPagedList<ImportPayment> Filter(int rows, int pageNumber, int? PayToType);
        IQueryable<ImportPayment> FindOne(int ImportPaymentId);
        ImportPaymentViewModel FindOneMapped(int ImportPaymentId);
    }
}

