namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public interface INashUserRepository : IRepository<NashUser>
    {
        IPagedList<NashUser> Filter(int rows, int pageNumber, int? nashUserTypeId,string SearchString="");
        IQueryable<NashUser> FindOne(int nashUserId);
        NashUserViewModel FindOneMapped(int nashUserId);
        IList<NashUserType> GetNashUserType();
    }
}

