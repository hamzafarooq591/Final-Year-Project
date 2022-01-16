namespace NashWebApi.Services
{
    using NashWebApi;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Exceptions.NashHandledException;
    using NashWebApi.Extensions;
    using NashWebApi.Mappers;
    using NashWebApi.Repositories;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constant;

    public class OrderService : IOrderService
    {
        public OrderViewModel CreateOrder(OrderBindingModel model, int userId)
        {
            Order entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            OrderViewModel model2 = new OrderViewModel();
            OrderRepository repository = new OrderRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteOrder(int OrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderRepository repository = new OrderRepository(context);
            Order entity = repository.FindOne(OrderId).FirstOrDefault<Order>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OrderId. Order Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public OrderViewModel GetOrderByOrderId(int OrderId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderRepository repository = new OrderRepository(context);
            if (repository.FindOne(OrderId).FirstOrDefault<Order>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OrderId. Order Not Found.");
            }
            return repository.FindOneMapped(OrderId);
        }

        public NashPagedList<OrderViewModel> GetOrder(int rows, int pageNumber, string CompanyName="", 
            string BranchName="", string CustomerName="",int? OrderStatusId=null , int? OrderId=null, DateTime? FromDate=null, DateTime? ToDate=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderRepository repository = new OrderRepository(context);
            return repository.Filter(rows, pageNumber, CompanyName, BranchName, 
                CustomerName, OrderStatusId, OrderId, FromDate,ToDate).ToViewModel();
        }
        
        public OrderViewModel UpdateOrder(OrderBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderRepository repository = new OrderRepository(context);
            int? OrderId = model.OrderId;
            Order original = repository.FindOne(OrderId.HasValue ? OrderId.GetValueOrDefault() : 0).FirstOrDefault<Order>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OrderId. Order Not Found.");
            }
            Order entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetOrderByOrderId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

