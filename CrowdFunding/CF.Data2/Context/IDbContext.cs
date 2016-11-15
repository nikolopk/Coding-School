using CF.Models.Database;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CF.Data2.Context
{
    public interface IDbContext
    {
        IDbSet<T> Set<T>() where T : class;
        int SaveChanges();
        DbEntityEntry Entry(object o);
        void Dispose();
    }

}
