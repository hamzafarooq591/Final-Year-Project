namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;

    public interface INashUserRoleService
    {
        NashUserRoleViewModel CreateNashUserRole(NashUserRoleBindingModel model, int userId);
        bool DeleteNashUserRole(int NashUserRoleId);
        NashUserRoleViewModel GetNashUserRoleByNashUserRoleId(int NashUserRoleId);
        NashPagedList<NashUserRoleViewModel> GetNashUserRoles(int rows, int pageNumber);
        NashUserRoleViewModel UpdateNashUserRole(NashUserRoleBindingModel model, int userId);
    }
}

