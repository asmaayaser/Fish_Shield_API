using Microsoft.EntityFrameworkCore;
using Repositories.Context;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repositories
{
    public abstract class Repositorybase<T> : IRepositorybase<T> where T : class
    {
        protected readonly RepositoryContext context;

        public Repositorybase(RepositoryContext context)
        {
            this.context = context;
        }


        public void Add(T entity)=>context.Add(entity);
        public void Update(T entity)=>context.Update(entity);
        public void Delete(T entity)=>context.Remove(entity);
       

       
        public IQueryable<T> FindAll(bool TrackChanges)
        => !TrackChanges ? context.Set<T>().AsNoTracking() : context.Set<T>();

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression, bool TrackChanges)
       =>!TrackChanges?context.Set<T>().Where(expression).AsNoTracking():context.Set<T>().Where(expression);
    }
}