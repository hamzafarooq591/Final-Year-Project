namespace NashWebApi.Repositories.BloodLab
{
    using NashWebApi.Entities.BloodLab;
    using NashWebApi.ViewModels.BloodLab;
    using PagedList;
    using System;
    using System.Linq;

    public interface IAppointmentTestResultRepository : IRepository<AppointmentTestResult>
    {
        IPagedList<AppointmentTestResult> Filter(int rows, int pageNumber);
        IQueryable<AppointmentTestResult> FindOne(int AppointmenTestResultId);
        AppointmentTestResultViewModel FindOneMapped(int AppointmenTestResultId);
    }
}

