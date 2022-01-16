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
    
    public class PaymentDetailRepository : Repository<PaymentDetail>, IPaymentDetailRepository, IRepository<PaymentDetail>
    {
        public PaymentDetailRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<PaymentDetail> Filter(int rows, int pageNumber)
        {
            var result = NashContext.PaymentDetails
                .Include(x => x.BankAccount)
                .Include(x => x.PaymentStatus)
                .Include(x => x.PaymentType)
                .Include(x => x.PayToType)
                .Include(x => x.Customer)
                .Include(x => x.ImageProof)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<PaymentDetail>(pageNumber, rows);
        }
         
        public PaymentDetailViewModel FindOneMapped(int PaymentDetailId) =>
            this.FindOne(PaymentDetailId).FirstOrDefault<PaymentDetail>().ToViewModel();

        public IQueryable<PaymentDetail> FindOne(int PaymentDetailId)
        {
            return NashContext.PaymentDetails
                .Include(x => x.BankAccount)
                .Include(x => x.PaymentStatus)
                .Include(x => x.PaymentType)
                .Include(x => x.PayToType)
                .Include(x => x.Customer)
                .Include(x => x.ImageProof)
                .Where(x => x.Id == PaymentDetailId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

