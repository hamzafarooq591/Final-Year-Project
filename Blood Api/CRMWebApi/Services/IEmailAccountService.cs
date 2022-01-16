namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IEmailAccountService
    {
        EmailAccountViewModel CreateEmailAccount(EmailAccountBindingModel model, int userId);
        bool DeleteEmailAccount(int EmailAccountId);
        EmailAccountViewModel GetEmailAccountByEmailAccountId(int EmailAccountId);
        NashPagedList<EmailAccountViewModel> GetEmailAccount(int rows, int pageNumber );
        EmailAccountViewModel UpdateEmailAccount(EmailAccountBindingModel model, int userId);
    }
}

