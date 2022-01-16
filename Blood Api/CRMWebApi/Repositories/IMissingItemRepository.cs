namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IMissingItemRepository : IRepository<MissingItem>
    {
        IPagedList<MissingItem> Filter(int rows, int pageNumber);
        IQueryable<MissingItem> FindOne(int MissingItemId);
        MissingItemViewModel FindOneMapped(int MissingItemId);
    }
}

