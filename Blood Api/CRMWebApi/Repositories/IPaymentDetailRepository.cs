namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPaymentDetailRepository : IRepository<PaymentDetail>
    {
        IPagedList<PaymentDetail> Filter(int rows, int pageNumber);
        IQueryable<PaymentDetail> FindOne(int PaymentDetailId);
        PaymentDetailViewModel FindOneMapped(int PaymentDetailId);
    }
}

