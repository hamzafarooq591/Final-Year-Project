namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAppointmentTestRepository : IRepository<AppointmentTest>
    {
        IPagedList<AppointmentTest> Filter(int rows, int pageNumber);
        IQueryable<AppointmentTest> FindOne(int AppointmenTestId);
        AppointmentTestViewModel FindOneMapped(int AppointmenTestId);
    }
}

