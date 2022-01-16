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
    
    public class InvoiceMasterRepository : Repository<InvoiceMaster>, IInvoiceMasterRepository, IRepository<InvoiceMaster>
    {
        public InvoiceMasterRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<InvoiceMaster> Filter(int rows, int pageNumber, int? BillToType)
        {
            var result = NashContext.InvoiceMasters
                .Include(x => x.BillToType)
                .Include(x => x.Company)
                .Include(x => x.ImageUpload)
               .Where(x =>  x.IsDeleted == false && (x.BillToTypeId == BillToType));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<InvoiceMaster>(pageNumber, rows);
        }
         
        public InvoiceMasterViewModel FindOneMapped(int InvoiceMasterId) =>
            this.FindOne(InvoiceMasterId).FirstOrDefault<InvoiceMaster>().ToViewModel();

        public IQueryable<InvoiceMaster> FindOne(int InvoiceMasterId)
        {
            return NashContext.InvoiceMasters
                .Include(x => x.BillToType)
                .Include(x => x.Company)
                .Include(x => x.ImageUpload)
                .Where(x => x.Id == InvoiceMasterId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

