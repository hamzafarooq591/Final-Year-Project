namespace NashWebApi.Services
{
    using NashWebApi;
    using NashWebApi.BindingModels;
    using NashWebApi.Entities;
    using NashWebApi.Exceptions.NashHandledException;
    using NashWebApi.Extensions;
    using NashWebApi.Mappers;
    using NashWebApi.Repositories;
    using NashWebApi.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Constant;
    using NashWebApi.ViewModels.BloodLab;

    public class TestService : ITestService
    {
        public TestViewModel CreateTest(TestBindingModel model, int userId)
        {
            Test entity = model.ToEntity(userId, null);

            NashWebApi.NashContext context = new NashWebApi.NashContext();

            TestViewModel model2 = new TestViewModel();
            TestRepository repository = new TestRepository(context);
            Test test = repository.GetAll().
                FirstOrDefault(x => x.Title.Contains(entity.Title));
           
            using (UnitOfWork work = new UnitOfWork(context))
            {
                if (test != null)
                {
                    throw new NashHandledExceptionNotFound("Test Name already Exist, Try another Name");
                }
                else
                {
                    entity = repository.Add(entity);
                    work.Complete();
                    return repository.FindOneMapped(entity.Id);
                }
            }
        }

        public bool DeleteTest(int TestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            TestRepository repository = new TestRepository(context);
            Test entity = repository.FindOne(TestId).FirstOrDefault<Test>();
          
            if (entity == null)
            {
                throw new NashHandledExceptionNotFound("Invalid TestId. Test Not Found.");
            }
          
           // if (entity.TestHeadId != null)
           // {
                entity.IsDeleted = true;
                using (UnitOfWork work = new UnitOfWork(context))
                {
                    repository.Edit(entity);
                    work.Complete();
                }
                return true;
            //}
            //else
              //  throw new NashException("Head Test can't be deleted.");
        }

        public TestViewModel GetTestByTestId(int TestId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            TestRepository repository = new TestRepository(context);
            if (repository.FindOne(TestId).FirstOrDefault<Test>() == null)
            {
                throw new NashHandledExceptionNotFound("Invalid TestId. Test Not Found.");
            }
            var result = repository.FindOneMapped(TestId);

            return result;
        }

        public NashPagedList<TestViewModel> GetTest(int rows, int pageNumber, int? BranchId=null)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            TestRepository repository = new TestRepository(context);
            //SearchString = string.IsNullOrEmpty(SearchString) ? "" : SearchString;

            var result = repository.Filter(rows, pageNumber).ToViewModel();

            return result;
        }

        public TestViewModel UpdateTest(TestBindingModel model, int userId)
        {
            NashWebApi.NashContext context = new NashWebApi.NashContext();
            TestRepository repository = new TestRepository(context);
            int? TestId = model.TestId;
            Test original = repository.FindOne(TestId.HasValue ? TestId.GetValueOrDefault() : 0).FirstOrDefault<Test>();
            if (original == null)
            {
                throw new NashHandledExceptionNotFound("Invalid TestId. Test Not Found.");
            }
            Test entity = model.ToEntity(userId, original);
            
            using (UnitOfWork work = new UnitOfWork(context))
            {
                repository.Edit(entity);
                work.Complete();
            }
            return this.GetTestByTestId(entity.Id);
        }

       

        public class TestChild
        {
            public int testId {get;set;}
            public float totaldebit { get; set; }
            public float totalcredit { get; set; }
        }

        //get Profit & Loss()
        public NashWebApi.NashContext NashContext =>
            this.NashContext;
    }
}

