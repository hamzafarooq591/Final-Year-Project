namespace NashWebApi.Repositories
{
    using NashWebApi;
    using NashWebApi.Entities;
    using NashWebApi.Mappers;
    using NashWebApi.ViewModels;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;
    using NashWebApi.ViewModels.BloodLab;

    public class TestRepository : Repository<Test>, ITestRepository, IRepository<Test>
    {
        public TestRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Test> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Tests
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Test>(pageNumber, rows);
        }
        //ParentTestId List
        
        public TestViewModel FindOneMapped(int TestId) =>
            this.FindOne(TestId).FirstOrDefault<Test>().ToViewModel();

        public IQueryable<Test> FindOne(int TestId)
        {
            return NashContext.Tests
                .Where(x => x.Id == TestId && x.IsDeleted == false);
        }

      

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

