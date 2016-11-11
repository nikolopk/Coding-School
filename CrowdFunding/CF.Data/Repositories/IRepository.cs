using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CF.Data.Repositories
{
    public interface IRepository<T> : IRepositoryBase where T : class
    {
        T GetById(params object[] keyValues);

        IQueryable<T> GetAll();
        IQueryable<T> GetWhere(Expression<Func<T, bool>> filter);
        IQueryable<T> GetWhereOrderBy(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);

        T Insert(T entity);
        T Attach(T entity);
        void Delete(params object[] keyValues);
        void Delete(T entity);
        T Update(T entity);
    }
}
