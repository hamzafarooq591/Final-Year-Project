namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IDcGroupService
    {
        DcGroupViewModel CreateDcGroup(DcGroupBindingModel model, int userId);
        bool DeleteDcGroup(int DcGroupId);
        DcGroupViewModel GetDcGroupByDcGroupId(int DcGroupId);
        NashPagedList<DcGroupViewModel> GetDcGroup(int rows, int pageNumber );
        DcGroupViewModel UpdateDcGroup(DcGroupBindingModel model, int userId);
    }
}

