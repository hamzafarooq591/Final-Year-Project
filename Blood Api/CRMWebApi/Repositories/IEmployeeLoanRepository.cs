namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IEmployeeLoanRepository : IRepository<EmployeeLoan>
    {
        IPagedList<EmployeeLoan> Filter(int rows, int pageNumber);
        IQueryable<EmployeeLoan> FindOne(int EmployeeLoanId);
        EmployeeLoanViewModel FindOneMapped(int EmployeeLoanId);
    }
}

