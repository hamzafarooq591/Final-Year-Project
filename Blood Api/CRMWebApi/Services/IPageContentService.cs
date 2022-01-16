namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IPageContentService
    {
        PageContentViewModel CreatePageContent(PageContentBindingModel model, int userId);
        bool DeletePageContent(int PageContentId);
        PageContentViewModel GetPageContentByPageContentId(int PageContentId);
        NashPagedList<PageContentViewModel> GetPageContent(int rows, int pageNumber);
        PageContentViewModel UpdatePageContent(PageContentBindingModel model, int userId);
    }
}

