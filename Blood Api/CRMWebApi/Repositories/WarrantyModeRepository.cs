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

    public class WarrantyModeRepository : Repository<WarrantyMode>, IWarrantyModeRepository, IRepository<WarrantyMode>
    {
        public WarrantyModeRepository(NashWebApi.NashContext context) : base(context)
        {
        }

        public IPagedList<WarrantyMode> Filter(int rows, int pageNumber)
        {

            return NashContext.WarrantyModes
                .Where(x => x.IsDeleted == false)
                .OrderByDescending(o => o.Id)
                .ToPagedList<WarrantyMode>(pageNumber, rows);
        }

        public IQueryable<WarrantyMode> FindOne(int WarrantyModeId)
        {

            return NashContext.WarrantyModes
                .Where(x => x.IsDeleted == false && x.Id == WarrantyModeId);
        }

        public WarrantyModeViewModel FindOneMapped(int WarrantyModeId) =>
            this.FindOne(WarrantyModeId).FirstOrDefault<WarrantyMode>().ToViewModel();

        public NashWebApi.NashContext NashContext =>
            (base.Context as NashWebApi.NashContext);
    }
}

