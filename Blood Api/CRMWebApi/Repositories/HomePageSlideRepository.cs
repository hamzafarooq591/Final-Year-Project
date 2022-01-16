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
    
    public class HomePageSlideRepository : Repository<HomePageSlide>, IHomePageSlideRepository, IRepository<HomePageSlide>
    {
        public HomePageSlideRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<HomePageSlide> Filter(int rows, int pageNumber)
        {
            var result = NashContext.HomePageSlides
                .Include(x => x.SlideImage)
               .Where(x =>  x.IsDeleted == false);
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<HomePageSlide>(pageNumber, rows);
        }
         
        public HomePageSlideViewModel FindOneMapped(int HomePageSlideId) =>
            this.FindOne(HomePageSlideId).FirstOrDefault<HomePageSlide>().ToViewModel();

        public IQueryable<HomePageSlide> FindOne(int HomePageSlideId)
        {
            return NashContext.HomePageSlides
                .Include(x => x.SlideImage)
                .Where(x => x.Id == HomePageSlideId && x.IsDeleted == false);
        }

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

