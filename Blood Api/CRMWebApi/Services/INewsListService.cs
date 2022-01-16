namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface INewsListService
    {
        NewsListViewModel CreateNewsList(NewsListBindingModel model, int userId);
        bool DeleteNewsList(int NewsListId);
        NewsListViewModel GetNewsListByNewsListId(int NewsListId);
        NashPagedList<NewsListViewModel> GetNewsList(int rows, int pageNumber );
        NewsListViewModel UpdateNewsList(NewsListBindingModel model, int userId);
    }
}

