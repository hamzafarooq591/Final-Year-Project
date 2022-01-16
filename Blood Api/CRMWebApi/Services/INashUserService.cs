namespace NashWebApi.Services
{
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Extensions;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;

    public interface INashUserService
    {
        NashUserViewModel CreateNashUser(NashUserBindingModel model, int userId);
        bool DeleteNashUser(int nashUserId);
        IList<NashRole> GetNashRoles();
        NashUserViewModel GetNashUserByNashUserId(int nashUserId);
        NashPagedList<NashUserViewModel> GetNashUsers(int rows, int pageNumber, int? nashUserTypeId , string SearchString="");
        IList<NashUserType> GetNashUserTypes();
        NashUserViewModel UpdateNashUser(NashUserBindingModel model, int userId);
        NashUserSessionViewModel CreateNashUserSession(NashUserSessionBindingModel model, int userId);
        NashUserSessionViewModel UpdateNashUserSession(NashUserSessionBindingModel model, int userId);
        bool DeleteNashUserSession(int NashUserSessionId);
        NashUserSessionViewModel GetNashUserSessionByNashUserSessionId(int NashUserSessionId);
        NashPagedList<NashUserSessionViewModel> GetNashUserSessionsByNashUserId
            (int rows, int pageNumber, int? NashUserId);
        NashUserSessionViewModel AuthenticateUser(AuthendicateBindingModel model, int userId);
        bool ValidateSession(String SessionKey, int userId);
        NashUserTypeViewModel CreateNashUserType(NashUserTypeBindingModel model, int userId);
    }
}

