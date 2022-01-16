namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IOrderProductWarrantyRepository : IRepository<OrderProductWarranty>
    {
        IPagedList<OrderProductWarranty> Filter(int rows, int pageNumber, string SearchString = "");
        IQueryable<OrderProductWarranty> FindOne(int OrderProductWarrantyId);
        OrderProductWarrantyViewModel FindOneMapped(int OrderProductWarrantyId);
    }
}

