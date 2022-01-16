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
    
    public class InvoiceDetailRepository : Repository<InvoiceDetail>, IInvoiceDetailRepository, IRepository<InvoiceDetail>
    {
        public InvoiceDetailRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<InvoiceDetail> Filter(int rows, int pageNumber)
        {
            var result = NashContext.InvoiceDetails
                .Include(x => x.InvoiceMaster)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<InvoiceDetail>(pageNumber, rows);
        }
         
        public InvoiceDetailViewModel FindOneMapped(int InvoiceDetailId) =>
            this.FindOne(InvoiceDetailId).FirstOrDefault<InvoiceDetail>().ToViewModel();

        public IQueryable<InvoiceDetail> FindOne(int InvoiceDetailId)
        {
            return NashContext.InvoiceDetails
                .Include(x => x.InvoiceMaster)
                .Where(x => x.Id == InvoiceDetailId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

