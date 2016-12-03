using CF.Data.Context;
using System;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace CF.Data.Repositories
{
    public class Repository<T> : Disposable, IRepository<T> where T : class
    {
        private readonly ICrowdFundingDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(ICrowdFundingDbContext context)
        {
            _context = context;
            _set = _context.Set<T>();
        }

        public virtual T GetById(params object[] keyValues)
        {
            return _set.Find(keyValues);
        }

        public virtual IQueryable<T> GetAll()
        {
            return _set;
        }

        public virtual IQueryable<T> GetWhere(Expression<Func<T, bool>> filter)
        {
            return _set.Where(filter);
        }

        public virtual IQueryable<T> GetWhereOrderBy(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return orderBy(_set.Where(filter));
        }

        public virtual T Insert(T entity)
        {
            return _set.Add(entity);
        }

        public virtual T Attach(T entity)
        {
            return _set.Attach(entity);
        }

        public virtual void Delete(params object[] keyValues)
        {
            Delete(GetById(keyValues));
        }

        public virtual void Delete(T entity)
        {
            if (entity != null)
            {
                if (_context.Entry(entity).State == EntityState.Detached)
                {
                    _set.Attach(entity);
                }

                _set.Remove(entity);
            }
        }

        public virtual T Update(T entity)
        {
            if (entity != null)
            {
                _set.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
            }

            return entity;
        }

        protected override void DisposeCore()
        {
            //base.DisposeCore();
        }

    }
}
