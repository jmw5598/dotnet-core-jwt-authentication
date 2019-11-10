using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;

using Auth.Core.Interfaces;

namespace Auth.Infrastructure.Data
{
    public abstract class BaseRepository<T> : IRepository<T> where T : class
    {
        private readonly DbContext _context;

        public BaseRepository(DbContext context)
        {
            this._context = context;
        }

        public IQueryable<T> FindAll()
        {
            return this._context.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return this._context.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            this._context.Set<T>().Add(entity);
            this._context.SaveChanges();
        }

        public void Update(T entity)
        {
            this._context.Set<T>().Update(entity);
            this._context.Entry(entity).State = EntityState.Modified;
            this._context.SaveChanges();

        }

        public void Delete(T entity)
        {
            this._context.Set<T>().Remove(entity);
            this._context.SaveChanges();
        }
        
    }
}