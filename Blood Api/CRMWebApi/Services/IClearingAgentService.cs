namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IClearingAgentService
    {
        ClearingAgentViewModel CreateClearingAgent(ClearingAgentBindingModel model, int userId);
        bool DeleteClearingAgent(int ClearingAgentId);
        ClearingAgentViewModel GetClearingAgentByClearingAgentId(int ClearingAgentId);
        NashPagedList<ClearingAgentViewModel> GetClearingAgent(int rows, int pageNumber);
        ClearingAgentViewModel UpdateClearingAgent(ClearingAgentBindingModel model, int userId);
    }
}

