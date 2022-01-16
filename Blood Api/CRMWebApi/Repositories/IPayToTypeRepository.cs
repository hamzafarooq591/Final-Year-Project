namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPayToTypeRepository : IRepository<PayToType>
    {
        IPagedList<PayToType> Filter(int rows, int pageNumber);
        IQueryable<PayToType> FindOne(int PayToTypeId);
        PayToTypeViewModel FindOneMapped(int PayToTypeId);
    }
}

