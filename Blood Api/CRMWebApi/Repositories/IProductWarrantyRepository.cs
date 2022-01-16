namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IProductWarrantyRepository : IRepository<ProductWarranty>
    {
        IPagedList<ProductWarranty> Filter(int rows, int pageNumber);
        IQueryable<ProductWarranty> FindOne(int ProductWarrantyId);
        ProductWarrantyViewModel FindOneMapped(int ProductWarrantyId);
    }
}

