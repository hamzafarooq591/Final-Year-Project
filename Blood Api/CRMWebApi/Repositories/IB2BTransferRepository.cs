namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IB2BTransferRepository : IRepository<B2BTransfer>
    {
        IPagedList<B2BTransfer> Filter(int rows, int pageNumber);
        IQueryable<B2BTransfer> FindOne(int B2BTransferId);
        B2BTransferViewModel FindOneMapped(int B2BTransferId);
    }
}

