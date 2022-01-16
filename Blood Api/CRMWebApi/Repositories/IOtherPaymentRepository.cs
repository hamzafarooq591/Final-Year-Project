namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IOtherPaymentRepository : IRepository<OtherPayment>
    {
        IPagedList<OtherPayment> Filter(int rows, int pageNumber);
        IQueryable<OtherPayment> FindOne(int OtherPaymentId);
        OtherPaymentViewModel FindOneMapped(int OtherPaymentId);
    }
}

