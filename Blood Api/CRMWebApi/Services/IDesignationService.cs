namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IDesignationService
    {
        DesignationViewModel CreateDesignation(DesignationBindingModel model, int userId);
        bool DeleteDesignation(int DesignationId);
        DesignationViewModel GetDesignationByDesignationId(int DesignationId);
        NashPagedList<DesignationViewModel> GetDesignation(int rows, int pageNumber );
        DesignationViewModel UpdateDesignation(DesignationBindingModel model, int userId);
    }
}

