namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.Mappers.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;
    using System.Collections.Generic;
    
    public class AppointmentTestRepository : Repository<AppointmentTest>, IAppointmentTestRepository, IRepository<AppointmentTest>
    {
        public AppointmentTestRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<AppointmentTest> Filter(int rows, int pageNumber)
        {
            var result = NashContext.AppointmentTests
                .Include(x=> x.Test)
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<AppointmentTest>(pageNumber, rows);
        }
        //ParentAppointmentTestId List
        
        public AppointmentTestViewModel FindOneMapped(int AppointmentTestId) =>
            this.FindOne(AppointmentTestId).FirstOrDefault<AppointmentTest>().ToViewModel();

        public List<AppointmentTest> FindAllByAppointmentId(int AppointmentId)
        {
            return NashContext.AppointmentTests
                .Include(x => x.Test)
                .Where(x => x.AppointmentId == AppointmentId && x.IsDeleted == false).ToList<AppointmentTest>();
        }
        public IQueryable<AppointmentTest> FindOne(int AppointmentTestId)
        {
            return NashContext.AppointmentTests
                 .Include(x => x.Test)
                .Where(x => x.Id == AppointmentTestId && x.IsDeleted == false);
        }

      

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

