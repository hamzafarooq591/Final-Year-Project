namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;

    public class InventoryStockRepository : Repository<InventoryStock>, IInventoryStockRepository, IRepository<InventoryStock>
    {
        public InventoryStockRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<InventoryStock> Filter(int rows, int pageNumber)
        {

            return NashContext.InventoryStocks
                .Include(x => x.Product)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<InventoryStock>(pageNumber, rows);
        }

        public IQueryable<InventoryStock> FindOne(int InventoryStockId)
        {

            return NashContext.InventoryStocks
                .Include(x => x.Product)
                .Where(x => x.IsDeleted == false && x.Id == InventoryStockId);
        }

        public InventoryStockViewModel FindOneMapped(int InventoryStockId) =>
            this.FindOne(InventoryStockId).FirstOrDefault<InventoryStock>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

