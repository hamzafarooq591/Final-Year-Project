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

    public class ApprovalRepository : Repository<Approval>, IApprovalRepository, IRepository<Approval>
    {
        public ApprovalRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<Approval> Filter(int rows, int pageNumber)
        {

            return NashContext.Approvals
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<Approval>(pageNumber, rows);
        }

        public IQueryable<Approval> FindOne(int ApprovalId)
        {

            return NashContext.Approvals
                .Where(x => x.IsDeleted == false && x.Id == ApprovalId);
        }

        public ApprovalViewModel FindOneMapped(int ApprovalId) =>
            this.FindOne(ApprovalId).FirstOrDefault<Approval>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

