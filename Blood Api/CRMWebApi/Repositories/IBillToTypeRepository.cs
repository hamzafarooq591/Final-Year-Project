namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IBillToTypeRepository : IRepository<BillToType>
    {
        IPagedList<BillToType> Filter(int rows, int pageNumber);
        IQueryable<BillToType> FindOne(int BillToTypeId);
    }
}

