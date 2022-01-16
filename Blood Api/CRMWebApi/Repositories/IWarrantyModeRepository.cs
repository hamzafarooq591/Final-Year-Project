namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IWarrantyModeRepository : IRepository<WarrantyMode>
    {
        IPagedList<WarrantyMode> Filter(int rows, int pageNumber);
        IQueryable<WarrantyMode> FindOne(int WarrantyModeId);
        WarrantyModeViewModel FindOneMapped(int WarrantyModeId);
    }
}

