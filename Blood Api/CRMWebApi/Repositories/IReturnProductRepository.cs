namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IReturnProductRepository : IRepository<ReturnProduct>
    {
        IPagedList<ReturnProduct> Filter(int rows, int pageNumber);
        IQueryable<ReturnProduct> FindOne(int ReturnProductId);
        ReturnProductViewModel FindOneMapped(int ReturnProductId);
    }
}

