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
    
    public class OtherPaymentRepository : Repository<OtherPayment>, IOtherPaymentRepository, IRepository<OtherPayment>
    {
        public OtherPaymentRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<OtherPayment> Filter(int rows, int pageNumber)
        {
            var result = NashContext.OtherPayments
                .Include(x => x.Branch)
                .Include(x => x.Branch.Company)
                .Include(x => x.BankAccount)
                .Include(x => x.PaymentType)
                .Include(x => x.ImageProof)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<OtherPayment>(pageNumber, rows);
        }
         
        public OtherPaymentViewModel FindOneMapped(int OtherPaymentId) =>
            this.FindOne(OtherPaymentId).FirstOrDefault<OtherPayment>().ToViewModel();

        public IQueryable<OtherPayment> FindOne(int OtherPaymentId)
        {
            return NashContext.OtherPayments
                .Include(x => x.Branch)
                .Include(x => x.Branch.Company)
                .Include(x => x.BankAccount)
                .Include(x => x.PaymentType)
                .Include(x => x.ImageProof)
                .Where(x => x.Id == OtherPaymentId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

