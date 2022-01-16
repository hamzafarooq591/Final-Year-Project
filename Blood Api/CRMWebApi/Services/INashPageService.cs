namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;

    public interface INashPageService
    {
        NashPageViewModel CreateNashPage(NashPageBindingModel model, int userId);
        bool DeleteNashPage(int NashPageId);
        NashPageViewModel GetNashPageByNashPageId(int NashPageId);
        NashPagedList<NashPageViewModel> GetNashPages(int rows, int pageNumber);
        NashPageViewModel UpdateNashPage(NashPageBindingModel model, int userId);
    }
}

