namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface INewsLetterTemplateService
    {
        NewsLetterTemplateViewModel CreateNewsLetterTemplate(NewsLetterTemplateBindingModel model, int userId);
        bool DeleteNewsLetterTemplate(int NewsLetterTemplateId);
        NewsLetterTemplateViewModel GetNewsLetterTemplateByNewsLetterTemplateId(int NewsLetterTemplateId);
        NashPagedList<NewsLetterTemplateViewModel> GetNewsLetterTemplate(int rows, int pageNumber );
        NewsLetterTemplateViewModel UpdateNewsLetterTemplate(NewsLetterTemplateBindingModel model, int userId);
    }
}

