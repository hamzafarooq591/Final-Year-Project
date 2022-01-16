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
    
    public class SaleDeliveryItemRepository : Repository<SaleDeliveryItem>, ISaleDeliveryItemRepository, IRepository<SaleDeliveryItem>
    {
        public SaleDeliveryItemRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<SaleDeliveryItem> Filter(int rows, int pageNumber, bool? isCompleted = null)
        {
            var result = NashContext.SaleDeliveryItems
                .Include(x => x.Item)
                .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<SaleDeliveryItem>(pageNumber, rows);
        }

        public IPagedList<SaleDeliveryItem> FilterBySaleDeliveryId(int rows, int pageNumber, int saleDeliveryId)
        {
            var result = NashContext.SaleDeliveryItems
                .Include(x => x.Item)
                .Where(x => x.IsDeleted == false && x.SaleDeliveryId == saleDeliveryId);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<SaleDeliveryItem>(pageNumber, rows);
        }

        public List<SaleDeliveryItem> ListBySaleDeliveryId(int saleDeliveryId)
        {
            var result = NashContext.SaleDeliveryItems
                .Include(x => x.Item)
                .Where(x => x.IsDeleted == false && x.SaleDeliveryId == saleDeliveryId);
            return result.OrderByDescending(o => o.Id)
                .ToList();
        }

        public SaleDeliveryItemViewModel FindOneMapped(int SaleDeliveryItemId) =>
            this.FindOne(SaleDeliveryItemId).FirstOrDefault<SaleDeliveryItem>().ToViewModel();

        public IQueryable<SaleDeliveryItem> FindOne(int SaleDeliveryItemId)
        {
            return NashContext.SaleDeliveryItems
                .Include(x => x.Item)
                .Where(x => x.Id == SaleDeliveryItemId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

