namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi.Entities;
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAppointmentRepository : IRepository<Appointment>
    {
        IPagedList<Appointment> Filter(int rows, int pageNumber);
        IQueryable<Appointment> FindOne(int AppointmentId);
        AppointmentViewModel FindOneMapped(int AppointmentId);
    }
}

