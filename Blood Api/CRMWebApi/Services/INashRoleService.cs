namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface INashRoleService
    {
        NashRolesViewModel CreateNashRole(NashRolesBindingModel model, int userId);
        bool DeleteNashRole(int nashRoleId);
        NashRolesViewModel GetNashRoleByNashRoleId(int nashRoleId);
        NashPagedList<NashRolesViewModel> GetNashRole(int rows, int pageNumber , string SearchString = "");
        NashRolesViewModel UpdateNashRole(NashRolesBindingModel model, int userId);
    }
}

