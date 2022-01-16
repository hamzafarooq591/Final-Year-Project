namespace NashWebApi.Repositories
{
    using NashWebApi;
    using System;
    using System.Runtime.CompilerServices;

    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly NashContext _context;

        public UnitOfWork(NashContext context)
        {
            this._context = context;
            this.NashUsers = new NashUserRepository(this._context);
            this.NashPages = new NashPageRepository(this._context);
        }

        public int Complete() => 
            this._context.SaveChanges();

        public void Dispose()
        {
            this._context.Dispose();
        }

        public INashPageRepository NashPages { get; private set; }

        public INashUserRepository NashUsers { get; private set; }
    }
}

