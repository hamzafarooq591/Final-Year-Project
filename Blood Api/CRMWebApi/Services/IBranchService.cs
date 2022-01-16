namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IBranchService
    {
        BranchViewModel CreateBranch(BranchBindingModel model, int userId);
        bool DeleteBranch(int BranchId);
        BranchViewModel GetBranchByBranchId(int BranchId);
        NashPagedList<BranchViewModel> GetBranch(int rows, int pageNumber , int? CompanyId=null);
        BranchViewModel UpdateBranch(BranchBindingModel model, int userId);
    }
}

