namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface INewsLetterService
    {
        NewsLetterViewModel CreateNewsLetter(NewsLetterBindingModel model, int userId);
        bool DeleteNewsLetter(int NewsLetterId);
        NewsLetterViewModel GetNewsLetterByNewsLetterId(int NewsLetterId);
        NashPagedList<NewsLetterViewModel> GetNewsLetter(int rows, int pageNumber );
        NewsLetterViewModel UpdateNewsLetter(NewsLetterBindingModel model, int userId);
    }
}

