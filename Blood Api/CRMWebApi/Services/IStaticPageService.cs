namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IStaticPageService
    {
        StaticPageViewModel CreateStaticPage(StaticPageBindingModel model, int userId);
        bool DeleteStaticPage(int StaticPageId);
        StaticPageViewModel GetStaticPageByStaticPageId(int StaticPageId);
        NashPagedList<StaticPageViewModel> GetStaticPage(int rows, int pageNumber );
        StaticPageViewModel UpdateStaticPage(StaticPageBindingModel model, int userId);
    }
}

