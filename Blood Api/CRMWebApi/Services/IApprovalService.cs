namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IApprovalService
    {
        ApprovalViewModel CreateApproval(ApprovalBindingModel model, int userId);
        bool DeleteApproval(int ApprovalId);
        ApprovalViewModel GetApprovalByApprovalId(int ApprovalId);
        NashPagedList<ApprovalViewModel> GetApproval(int rows, int pageNumber );
        ApprovalViewModel UpdateApproval(ApprovalBindingModel model, int userId);
    }
}

