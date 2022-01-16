namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface IDcSummaryService
    {
        DcSummaryViewModel CreateDcSummary(DcSummaryBindingModel model, int userId);
        bool DeleteDcSummary(int DcSummaryId);
        DcSummaryViewModel GetDcSummaryByDcSummaryId(int DcSummaryId);
        NashPagedList<DcSummaryViewModel> GetDcSummary(int rows, int pageNumber);
        DcSummaryViewModel UpdateDcSummary(DcSummaryBindingModel model, int userId);
    }
}

