namespace NashWebApi.Repositories
{
    using NashWebApi.Entities;
    using NashWebApi.ViewModels;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface ITestRepository : IRepository<Test>
    {
        IPagedList<Test> Filter(int rows, int pageNumber);
        IQueryable<Test> FindOne(int TestId);
        TestViewModel FindOneMapped(int TestId);
    }
}

