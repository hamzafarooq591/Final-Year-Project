namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPaymentTypeRepository : IRepository<PaymentType>
    {
        IPagedList<PaymentType> Filter(int rows, int pageNumber);
        IQueryable<PaymentType> FindOne(int PaymentTypeId);
    }
}

