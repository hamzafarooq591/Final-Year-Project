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
    
    public class ImportPaymentRepository : Repository<ImportPayment>, IImportPaymentRepository, IRepository<ImportPayment>
    {
        public ImportPaymentRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<ImportPayment> Filter(int rows, int pageNumber, int? PayToType)
        {
            var result = NashContext.ImportPayments
                .Include(x => x.Company)
                .Include(x => x.Currency)
                .Include(x => x.BankAccount)
                .Include(x => x.PaymentType)
                .Include(x => x.MoneyChanger)
                .Include(x => x.PayToType)
               .Where(x =>  x.IsDeleted == false && (x.PayToTypeId == PayToType));
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<ImportPayment>(pageNumber, rows);
        }
         
        public ImportPaymentViewModel FindOneMapped(int ImportPaymentId) =>
            this.FindOne(ImportPaymentId).FirstOrDefault<ImportPayment>().ToViewModel();

        public IQueryable<ImportPayment> FindOne(int ImportPaymentId)
        {
            return NashContext.ImportPayments
                .Include(x => x.Company)
                .Include(x => x.Currency)
                .Include(x => x.BankAccount)
                .Include(x => x.PaymentType)
                .Include(x => x.MoneyChanger)
                .Include(x => x.PayToType)
                .Where(x => x.Id == ImportPaymentId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

