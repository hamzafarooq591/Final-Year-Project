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

    public class VendorPODetailRepository : Repository<VendorPODetail>, IVendorPODetailRepository, IRepository<VendorPODetail>
    {
        public VendorPODetailRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<VendorPODetail> Filter(int rows, int pageNumber)
        {

            return NashContext.VendorPODetails
                .Include(x => x.VendorPurchaseOrder)
                .Include(x => x.Product)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<VendorPODetail>(pageNumber, rows);
        }

        public IQueryable<VendorPODetail> FindOne(int VendorPODetailId)
        {

            return NashContext.VendorPODetails
                .Include(x => x.VendorPurchaseOrder)
                .Include(x => x.Product)
                .Where(x => x.IsDeleted == false && x.Id == VendorPODetailId);
        }

        public VendorPODetailViewModel FindOneMapped(int VendorPODetailId) =>
            this.FindOne(VendorPODetailId).FirstOrDefault<VendorPODetail>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

