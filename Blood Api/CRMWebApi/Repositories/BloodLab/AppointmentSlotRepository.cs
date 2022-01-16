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
    
    public class AppointmentSlotRepository : Repository<AppointmentSlot>, IAppointmentSlotRepository, IRepository<AppointmentSlot>
    {
        public AppointmentSlotRepository(NashWebApi.NashContext context) : base(context)
        {
        }
        public IPagedList<AppointmentSlot> Filter(int rows, int pageNumber)
        {
            var result = NashContext.AppointmentSlots
               .Where(x =>  x.IsDeleted == false );
            return result.OrderByDescending(o => o.Id)
                .ToPagedList<AppointmentSlot>(pageNumber, rows);
        }
        //ParentAppointmentSlotId List
        
        public AppointmentSlotViewModel FindOneMapped(int AppointmentSlotId) =>
            this.FindOne(AppointmentSlotId).FirstOrDefault<AppointmentSlot>().ToViewModel();

        public IQueryable<AppointmentSlot> FindOne(int AppointmentSlotId)
        {
            return NashContext.AppointmentSlots
                .Where(x => x.Id == AppointmentSlotId && x.IsDeleted == false);
        }

      

        public NashWebApi.NashContext NashContext =>
          (base.Context as NashWebApi.NashContext);
    }
}

