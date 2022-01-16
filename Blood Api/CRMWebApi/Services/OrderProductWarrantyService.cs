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

    public class OrderProductWarrantyService : IOrderProductWarrantyService
    {
        public OrderProductWarrantyViewModel CreateOrderProductWarranty(OrderProductWarrantyBindingModel model, int userId)
        {
            OrderProductWarranty entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            OrderProductWarrantyViewModel model2 = new OrderProductWarrantyViewModel();
            OrderProductWarrantyRepository repository = new OrderProductWarrantyRepository(context);
            OrderRepository orderRepository = new OrderRepository(context);
            ProductRepository productRepository = new ProductRepository(context);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                entity.StartDate = orderRepository.FindOne(entity.OrderId).FirstOrDefault().CreatedOn;
                int warrantydays = productRepository.FindOne(entity.ProductId).FirstOrDefault().WarrantyMode.WarrantyModePeriodInDays;
                entity.EndDate = entity.StartDate.AddDays(warrantydays);
                entity = repository.Add(entity);
                work.Complete();
                return repository.FindOneMapped(entity.Id);
            }
        }

        public bool DeleteOrderProductWarranty(int OrderProductWarrantyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderProductWarrantyRepository repository = new OrderProductWarrantyRepository(context);
            OrderProductWarranty entity = repository.FindOne(OrderProductWarrantyId).FirstOrDefault<OrderProductWarranty>();
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OrderProductWarrantyId. OrderProductWarranty Not Found.");
            }
            entity.IsDeleted = true;
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return true;
        }
        
        public OrderProductWarrantyViewModel GetOrderProductWarrantyByOrderProductWarrantyId(int OrderProductWarrantyId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderProductWarrantyRepository repository = new OrderProductWarrantyRepository(context);
            if (repository.FindOne(OrderProductWarrantyId).FirstOrDefault<OrderProductWarranty>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OrderProductWarrantyId. OrderProductWarranty Not Found.");
            }
            return repository.FindOneMapped(OrderProductWarrantyId);
        }

        public NashPagedList<OrderProductWarrantyViewModel> GetOrderProductWarranty(int rows, int pageNumber, string SearchString = "")
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderProductWarrantyRepository repository = new OrderProductWarrantyRepository(context);
            SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;
            return repository.Filter(rows, pageNumber, SearchString).ToViewModel();
        }
        
        public OrderProductWarrantyViewModel UpdateOrderProductWarranty(OrderProductWarrantyBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            OrderProductWarrantyRepository repository = new OrderProductWarrantyRepository(context);
            OrderRepository orderRepository = new OrderRepository(context);
            ProductRepository productRepository = new ProductRepository(context);
            int? OrderProductWarrantyId = model.OrderProductWarrantyId;
            OrderProductWarranty original = repository.FindOne(OrderProductWarrantyId.HasValue ? OrderProductWarrantyId.GetValueOrDefault() : 0).FirstOrDefault<OrderProductWarranty>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid OrderProductWarrantyId. OrderProductWarranty Not Found.");
            }
            OrderProductWarranty entity = model.ToEntity(userId, original);
            using (UnitOfWork work = new UnitOfWork(context))
            {
                int warrantydays = productRepository.FindOne(entity.ProductId).FirstOrDefault().WarrantyMode.WarrantyModePeriodInDays;
                entity.EndDate = entity.StartDate.AddDays(warrantydays);
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetOrderProductWarrantyByOrderProductWarrantyId(entity.Id);
        }

        


        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

