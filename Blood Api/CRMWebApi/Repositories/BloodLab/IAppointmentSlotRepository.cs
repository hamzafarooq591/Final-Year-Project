namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAppointmentSlotRepository : IRepository<AppointmentSlot>
    {
        IPagedList<AppointmentSlot> Filter(int rows, int pageNumber);
        IQueryable<AppointmentSlot> FindOne(int AppointmentSlotId);
        AppointmentSlotViewModel FindOneMapped(int AppointmentSlotId);
    }
}

