namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IFreightForwarderService
    {
        FreightForwarderViewModel CreateFreightForwarder(FreightForwarderBindingModel model, int userId);
        bool DeleteFreightForwarder(int FreightForwarderId);
        FreightForwarderViewModel GetFreightForwarderByFreightForwarderId(int FreightForwarderId);
        NashPagedList<FreightForwarderViewModel> GetFreightForwarder(int rows, int pageNumber);
        FreightForwarderViewModel UpdateFreightForwarder(FreightForwarderBindingModel model, int userId);
    }
}

