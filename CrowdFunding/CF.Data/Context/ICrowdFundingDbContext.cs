using CF.Models.Database;
using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace CF.Data.Context
{
    public interface ICrowdFundingDbContext : System.IDisposable
    {
        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbSet Set(Type entityType);

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        DbEntityEntry Entry(object entity);

        Database Database { get; }

        DbChangeTracker ChangeTracker { get; }
    }

}
