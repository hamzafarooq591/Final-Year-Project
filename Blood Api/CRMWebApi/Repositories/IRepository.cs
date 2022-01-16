namespace NashWebApi.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public interface IRepository<TEntity> where TEntity: class
    {
        TEntity Add(TEntity entity);
        void AddRange(IEnumerable<TEntity> entities);
        int Count(Expression<Func<TEntity, bool>> predicate);
        TEntity Delete(TEntity entity);
        void Edit(TEntity entity);
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(int id);
        IEnumerable<TEntity> GetAll();
        void RemoveRange(IEnumerable<TEntity> entities);
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    }
}

