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
    
    public class PurchaseDeliveryItemRepository : Repository<PurchaseDeliveryItem>, IPurchaseDeliveryItemRepository, IRepository<PurchaseDeliveryItem>
    {
        public PurchaseDeliveryItemRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<PurchaseDeliveryItem> Filter(int rows, int pageNumber, bool? isCompleted = null)
        {
            var result = NashContext.PurchaseDeliveryItems
                .Include(x => x.Item)
                .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<PurchaseDeliveryItem>(pageNumber, rows);
        }

        public IPagedList<PurchaseDeliveryItem> FilterByPurchaseDeliveryId(int rows, int pageNumber, int PurchaseDeliveryId)
        {
            var result = NashContext.PurchaseDeliveryItems
                .Include(x => x.Item)
                .Where(x => x.IsDeleted == false && x.PurchaseDeliveryId == PurchaseDeliveryId);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<PurchaseDeliveryItem>(pageNumber, rows);
        }

        public List<PurchaseDeliveryItem> ListByPurchaseDeliveryId(int PurchaseDeliveryId)
        {
            var result = NashContext.PurchaseDeliveryItems
                .Include(x => x.Item)
                .Where(x => x.IsDeleted == false && x.PurchaseDeliveryId == PurchaseDeliveryId);
            return result.OrderByDescending(o => o.Id)
                .ToList<PurchaseDeliveryItem>();
        }

        public PurchaseDeliveryItemViewModel FindOneMapped(int PurchaseDeliveryItemId) =>
            this.FindOne(PurchaseDeliveryItemId).FirstOrDefault<PurchaseDeliveryItem>().ToViewModel();

        public IQueryable<PurchaseDeliveryItem> FindOne(int PurchaseDeliveryItemId)
        {
            return NashContext.PurchaseDeliveryItems
                .Include(x => x.Item)
                .Where(x => x.Id == PurchaseDeliveryItemId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

