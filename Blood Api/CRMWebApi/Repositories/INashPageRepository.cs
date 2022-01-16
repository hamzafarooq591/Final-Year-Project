namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface INashPageRepository : IRepository<NashPage>
    {
        IPagedList<NashPage> Filter(int rows, int pageNumber);
        IQueryable<NashPage> FindOne(int NashPageId);
        NashPageViewModel FindOneMapped(int NashPageId);
    }
}

