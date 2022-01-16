namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IEmployeeBonusRepository : IRepository<EmployeeBonus>
    {
        IPagedList<EmployeeBonus> Filter(int rows, int pageNumber, string SearchString = "");
        IQueryable<EmployeeBonus> FindOne(int EmployeeBonusId);
        EmployeeBonusViewModel FindOneMapped(int EmployeeBonusId);
    }
}

