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
    
    public class WarrantyOrRepairRequestRepository : Repository<WarrantyOrRepairRequest>, IWarrantyOrRepairRequestRepository, IRepository<WarrantyOrRepairRequest>
    {
        public WarrantyOrRepairRequestRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<WarrantyOrRepairRequest> Filter(int rows, int pageNumber)
        {
            var result = NashContext.CreateWarrantys
                .Include(x => x.WarrantyRequestStatus)
                .Include(x => x.Customer.Account.Branch)
                .Include(x => x.Customer)
                .Include(x => x.Product)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<WarrantyOrRepairRequest>(pageNumber, rows);
        }
         
        public WarrantyOrRepairRequestViewModel FindOneMapped(int CreateWarrantyId) =>
            this.FindOne(CreateWarrantyId).FirstOrDefault<WarrantyOrRepairRequest>().ToViewModel();

        public IQueryable<WarrantyOrRepairRequest> FindOne(int CreateWarrantyId)
        {
            return NashContext.CreateWarrantys
                .Include(x => x.WarrantyRequestStatus)
               // .Include(x => x.Customer.Account.Branch)
                .Include(x => x.Customer)
                .Include(x => x.Product)
                .Where(x => x.Id == CreateWarrantyId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

