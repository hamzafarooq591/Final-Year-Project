namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IFreightForwarderRepository : IRepository<FreightForwarder>
    {
        IPagedList<FreightForwarder> Filter(int rows, int pageNumber);
        IQueryable<FreightForwarder> FindOne(int FreightForwarderId);
        FreightForwarderViewModel FindOneMapped(int FreightForwarderId);
    }
}

