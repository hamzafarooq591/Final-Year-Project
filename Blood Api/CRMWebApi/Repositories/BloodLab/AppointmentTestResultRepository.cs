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
    
    public class AppointmentTestResultRepository : Repository<AppointmentTestResult>, IAppointmentTestResultRepository, IRepository<AppointmentTestResult>
    {
        public AppointmentTestResultRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<AppointmentTestResult> Filter(int rows, int pageNumber)
        {
            var result = NashContext.AppointmentTestResults
               .Include(x => x.Appointment)
               .Include(x => x.Appointment.Patient)
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<AppointmentTestResult>(pageNumber, rows);
        }
        //ParentAppointmentTestResultId List

        public List<AppointmentTestResult> FindAllByAppointmentId(int AppointmentId)
        {
            return NashContext.AppointmentTestResults
                .Include(x => x.AppointmentTestResultImage)
                .Include(x => x.Appointment)
                .Include(x => x.Appointment.Patient)
                .Where(x => x.AppointmentId == AppointmentId && x.IsDeleted == false).ToList<AppointmentTestResult>();
        }

        public List<AppointmentTestResult> FindAllUnMappedByAppointmentId(int AppointmentId)
        {
            return NashContext.AppointmentTestResults
                .Where(x => x.AppointmentId == AppointmentId && x.IsDeleted == false)
                .ToList<AppointmentTestResult>();
        }

        public AppointmentTestResultViewModel FindOneMapped(int AppointmentTestResultId) =>
            this.FindOne(AppointmentTestResultId)
            .Include(x => x.Appointment)
            .Include(x => x.Appointment.Patient)
            .FirstOrDefault<AppointmentTestResult>().ToViewModel();

        public IQueryable<AppointmentTestResult> FindOne(int AppointmentTestResultId)
        {
            return NashContext.AppointmentTestResults
                .Where(x => x.Id == AppointmentTestResultId && x.IsDeleted == false);
        }

      

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

