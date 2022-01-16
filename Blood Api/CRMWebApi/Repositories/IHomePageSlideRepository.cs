namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IHomePageSlideRepository : IRepository<HomePageSlide>
    {
        IPagedList<HomePageSlide> Filter(int rows, int pageNumber);
        IQueryable<HomePageSlide> FindOne(int HomePageSlideId);
        HomePageSlideViewModel FindOneMapped(int HomePageSlideId);
    }
}

