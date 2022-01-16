namespace NashWebApi.Repositories
{
    using System;

    public interface IUnitOfWork : IDisposable
    {
        int Complete();

        INashPageRepository NashPages { get; }

        INashUserRepository NashUsers { get; }
    }
}

