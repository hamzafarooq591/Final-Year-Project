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
    
    public class VendorRepository : Repository<Vendor>, IVendorRepository, IRepository<Vendor>
    {
        public VendorRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Vendor> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Vendors
                .Include(x => x.Company)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Vendor>(pageNumber, rows);
        }
         
        public VendorViewModel FindOneMapped(int VendorId) =>
            this.FindOne(VendorId).FirstOrDefault<Vendor>().ToViewModel();

        public IQueryable<Vendor> FindOne(int VendorId)
        {
            return NashContext.Vendors
                .Include(x => x.Company)
                .Where(x => x.Id == VendorId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

