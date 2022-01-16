namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Linq;

    public interface IPayslipRepository : IRepository<Payslip>
    {
        IPagedList<Payslip> Filter(int rows, int pageNumber);
        IQueryable<Payslip> FindOne(int PayslipId);
        PayslipViewModel FindOneMapped(int PayslipId);
    }
}

