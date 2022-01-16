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
    
    public class WarrantyRepository : Repository<Warranty>, IWarrantyRepository, IRepository<Warranty>
    {
        public WarrantyRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Warranty> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Warranties
                .Include(x => x.Order)
                .Include(x => x.WarrantyMode)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Warranty>(pageNumber, rows);
        }
         
        public WarrantyViewModel FindOneMapped(int WarrantyId) =>
            this.FindOne(WarrantyId).FirstOrDefault<Warranty>().ToViewModel();

        public IQueryable<Warranty> FindOne(int WarrantyId)
        {
            return NashContext.Warranties
                .Include(x => x.Order)
                .Include(x => x.WarrantyMode)
                .Where(x => x.Id == WarrantyId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

