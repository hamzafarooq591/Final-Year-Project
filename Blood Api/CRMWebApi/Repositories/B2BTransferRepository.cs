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
    
    public class B2BTransferRepository : Repository<B2BTransfer>, IB2BTransferRepository, IRepository<B2BTransfer>
    {
        public B2BTransferRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<B2BTransfer> Filter(int rows, int pageNumber)
        {
            var result = NashContext.B2BTransfers
                .Include(x => x.Branch)
                .Include(x => x.Branch.Company)
                .Include(x => x.FromBankAccount)
                .Include(x => x.ToBankAccount)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<B2BTransfer>(pageNumber, rows);
        }
         
        public B2BTransferViewModel FindOneMapped(int B2BTransferId) =>
            this.FindOne(B2BTransferId).FirstOrDefault<B2BTransfer>().ToViewModel();

        public IQueryable<B2BTransfer> FindOne(int B2BTransferId)
        {
            return NashContext.B2BTransfers
                .Include(x => x.Branch)
                .Include(x => x.Branch.Company)
                .Include(x => x.FromBankAccount)
                .Include(x => x.ToBankAccount)
                .Where(x => x.Id == B2BTransferId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

