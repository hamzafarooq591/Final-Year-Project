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

    public class WarrantyRequestStatusRepository : Repository<WarrantyRequestStatus>, IWarrantyRequestStatusRepository, IRepository<WarrantyRequestStatus>
    {
        public WarrantyRequestStatusRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<WarrantyRequestStatus> Filter(int rows, int pageNumber)
        {

            return NashContext.WarrantyRequestStatuses
                .Include(x => x.Id)
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<WarrantyRequestStatus>(pageNumber, rows);
        }

        public IQueryable<WarrantyRequestStatus> FindOne(int WarrantyRequestStatusId)
        {

            return NashContext.WarrantyRequestStatuses
                .Include(x => x.Id)
                .Where(x => x.IsDeleted == false && x.Id == WarrantyRequestStatusId);
        }

        public WarrantyRequestStatusViewModel FindOneMapped(int WarrantyRequestStatusId) =>
            this.FindOne(WarrantyRequestStatusId).FirstOrDefault<WarrantyRequestStatus>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

