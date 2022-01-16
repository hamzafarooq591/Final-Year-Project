namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IItemRepository : IRepository<Item>
    {
        IPagedList<Item> Filter(int rows, int pageNumber);
        IQueryable<Item> FindOne(int ItemId);
        ItemViewModel FindOneMapped(int ItemId);
    }
}

