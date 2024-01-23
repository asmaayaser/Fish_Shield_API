using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories.Contracts
{
    public interface IRepositorybase<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
       IQueryable<T> FindAll(bool TrackChanges);
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool TrackChanges);
    }
}