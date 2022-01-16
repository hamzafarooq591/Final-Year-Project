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
    
    public class OrderProductWarrantyRepository : Repository<OrderProductWarranty>, IOrderProductWarrantyRepository, IRepository<OrderProductWarranty>
    {
        public OrderProductWarrantyRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<OrderProductWarranty> Filter(int rows, int pageNumber, string SearchString = "")
        {
            var result = NashContext.OrderProductWarranties
                .Include(x => x.Order)
                .Include(x => x.Product)
               .Where(x =>  x.IsDeleted == false && (SearchString == "" || x.MacAddress.Contains(SearchString)));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<OrderProductWarranty>(pageNumber, rows);
        }
         
        public OrderProductWarrantyViewModel FindOneMapped(int OrderProductWarrantyId) =>
            this.FindOne(OrderProductWarrantyId).FirstOrDefault<OrderProductWarranty>().ToViewModel();

        public IQueryable<OrderProductWarranty> FindOne(int OrderProductWarrantyId)
        {
            return NashContext.OrderProductWarranties
                .Include(x => x.Order)
                .Include(x => x.Product)
                .Where(x => x.Id == OrderProductWarrantyId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

