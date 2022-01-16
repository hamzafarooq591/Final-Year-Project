namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IHomePageSlideService
    {
        HomePageSlideViewModel CreateHomePageSlide(HomePageSlideBindingModel model, int userId);
        bool DeleteHomePageSlide(int HomePageSlideId);
        HomePageSlideViewModel GetHomePageSlideByHomePageSlideId(int HomePageSlideId);
        NashPagedList<HomePageSlideViewModel> GetHomePageSlide(int rows, int pageNumber);
        HomePageSlideViewModel UpdateHomePageSlide(HomePageSlideBindingModel model, int userId);
    }
}

