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
    
    public class PerformaInvoiceRepository : Repository<PerformaInvoice>, IPerformaInvoiceRepository, IRepository<PerformaInvoice>
    {
        public PerformaInvoiceRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<PerformaInvoice> Filter(int rows, int pageNumber)
        {
            var result = NashContext.PerformaInvoices
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<PerformaInvoice>(pageNumber, rows);
        }
         
        public PerformaInvoiceViewModel FindOneMapped(int PerformaInvoiceId) =>
            this.FindOne(PerformaInvoiceId).FirstOrDefault<PerformaInvoice>().ToViewModel();

        public IQueryable<PerformaInvoice> FindOne(int PerformaInvoiceId)
        {
            return NashContext.PerformaInvoices
                .Where(x => x.Id == PerformaInvoiceId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

