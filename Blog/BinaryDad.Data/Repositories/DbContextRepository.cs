using System;
using System.Data.Entity;

namespace BinaryDad.Data.Repositories
{
    public abstract class DbContextRepository<T> : IDisposable where T : DbContext, new()
    {
        protected T Context { get; private set; }

        protected DbContextRepository()
        {
            Context = new T();
        }

        public void Dispose()
        {
            Context.Dispose();
        }
    }
}
