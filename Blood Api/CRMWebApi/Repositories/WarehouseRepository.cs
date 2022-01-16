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
    
    public class WarehouseRepository : Repository<Warehouse>, IWarehouseRepository, IRepository<Warehouse>
    {
        public WarehouseRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Warehouse> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Warehouses
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Warehouse>(pageNumber, rows);
        }
         
        public WarehouseViewModel FindOneMapped(int WarehouseId) =>
            this.FindOne(WarehouseId).FirstOrDefault<Warehouse>().ToViewModel();

        public IQueryable<Warehouse> FindOne(int WarehouseId)
        {
            return NashContext.Warehouses
                .Where(x => x.Id == WarehouseId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

