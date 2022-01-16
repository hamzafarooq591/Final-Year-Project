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
    
    public class OrderRepository : Repository<Order>, IOrderRepository, IRepository<Order>
    {
        public OrderRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Order> Filter(int rows, int pageNumber, string CompanyName,
            string BranchName, string CustomerName, int? OrderStatusId, int? OrderId, DateTime? FromDate, DateTime? ToDate)
        {
            var result = NashContext.Orders
                .Include(x => x.Invoice)
                .Include(x => x.NashUser.Branch)
                .Include(x => x.NashUser.Branch.Company)
                .Include(x => x.Approval)
                .Include(x => x.Customer)
                .Include(x => x.NashUser)
                .Include(x => x.Product)
               .Where(x =>  x.IsDeleted == false && 
               ((CompanyName == "" || x.Customer.Account.Branch.Company.Name.Contains(CompanyName))
               &&
               (BranchName == "" || x.Customer.Account.Branch.BranchName.Contains(BranchName))
               &&
               (CustomerName == "" || x.Customer.CustomerName.Contains(CustomerName))
               &&
               (OrderId == null || x.Id == OrderId)
               &&
               (OrderStatusId == null || x.OrderStatusId == OrderStatusId)
               &&
               (FromDate == null || x.OrderPlacementDate >= FromDate)
               &&
               (ToDate == null || x.OrderPlacementDate <= ToDate)
               ));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Order>(pageNumber, rows);
        }
         
        public OrderViewModel FindOneMapped(int OrderId) =>
            this.FindOne(OrderId).FirstOrDefault<Order>().ToViewModel();

        public IQueryable<Order> FindOne(int OrderId)
        {
            return NashContext.Orders
                .Include(x => x.Invoice)
                .Include(x => x.NashUser.Branch)
                .Include(x => x.NashUser.Branch.Company)
                .Include(x => x.Approval)
                .Include(x => x.Customer)
                .Include(x => x.NashUser)
                .Include(x => x.Product)
                .Where(x => x.Id == OrderId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

