namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAdvanceSalaryRepository : IRepository<AdvanceSalary>
    {
        IPagedList<AdvanceSalary> Filter(int rows, int pageNumber);
        IQueryable<AdvanceSalary> FindOne(int AdvanceSalaryId);
        AdvanceSalaryViewModel FindOneMapped(int AdvanceSalaryId);
    }
}

