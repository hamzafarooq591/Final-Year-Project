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
    using NashWebApi.Entities;

    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository, IRepository<Appointment>
    {
        public AppointmentRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<Appointment> Filter(int rows, int pageNumber)
        {
            var result = NashContext.Appointments
                .Include(x => x.Patient)
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<Appointment>(pageNumber, rows);
        }
        //ParentAppointmentId List
        
        public AppointmentViewModel FindOneMapped(int AppointmentId) =>
            this.FindOne(AppointmentId)
            .Include(x => x.Patient)
            .FirstOrDefault<Appointment>().ToViewModel();

        public IQueryable<Appointment> FindOne(int AppointmentId)
        {
            return NashContext.Appointments
                .Include(x => x.Patient)
                .Where(x => x.Id == AppointmentId && x.IsDeleted == false);
        }

      

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

