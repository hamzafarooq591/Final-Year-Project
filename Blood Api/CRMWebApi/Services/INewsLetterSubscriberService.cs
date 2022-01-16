namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface INewsLetterSubscriberService
    {
        NewsLetterSubscriberViewModel CreateNewsLetterSubscriber(NewsLetterSubscriberBindingModel model, int userId);
        bool DeleteNewsLetterSubscriber(int NewsLetterSubscriberId);
        NewsLetterSubscriberViewModel GetNewsLetterSubscriberByNewsLetterSubscriberId(int NewsLetterSubscriberId);
        NashPagedList<NewsLetterSubscriberViewModel> GetNewsLetterSubscriber(int rows, int pageNumber);
        NewsLetterSubscriberViewModel UpdateNewsLetterSubscriber(NewsLetterSubscriberBindingModel model, int userId);
    }
}

