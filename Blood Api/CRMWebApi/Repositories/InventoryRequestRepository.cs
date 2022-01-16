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
    
    public class InventoryRequestRepository : Repository<InventoryRequest>, IInventoryRequestRepository, IRepository<InventoryRequest>
    {
        public InventoryRequestRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<InventoryRequest> Filter(int rows, int pageNumber)
        {
            var result = NashContext.InventoryRequests
                .Include(x => x.Branch)
                .Include(x => x.Product)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<InventoryRequest>(pageNumber, rows);
        }
         
        public InventoryRequestViewModel FindOneMapped(int InventoryRequestId) =>
            this.FindOne(InventoryRequestId).FirstOrDefault<InventoryRequest>().ToViewModel();

        public IQueryable<InventoryRequest> FindOne(int InventoryRequestId)
        {
            return NashContext.InventoryRequests
                .Include(x => x.Branch)
                .Include(x => x.Product)
                .Where(x => x.Id == InventoryRequestId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

