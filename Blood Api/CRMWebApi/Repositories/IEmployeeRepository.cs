namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IEmployeeRepository : IRepository<Employee>
    {
        IPagedList<Employee> Filter(int rows, int pageNumber, string SearchString = "");
        IQueryable<Employee> FindOne(int EmployeeId);
        EmployeeViewModel FindOneMapped(int EmployeeId);
    }
}

