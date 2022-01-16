namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IProductInStoreRepository : IRepository<ProductInStore>
    {
        IPagedList<ProductInStore> Filter(int rows, int pageNumber);
        IQueryable<ProductInStore> FindOne(int ProductInStoreId);
        ProductInStoreViewModel FindOneMapped(int ProductInStoreId);
    }
}

