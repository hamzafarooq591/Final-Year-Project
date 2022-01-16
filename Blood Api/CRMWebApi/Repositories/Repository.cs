namespace NashWebApi.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Linq.Expressions;

    public class Repository<TEntity> : IRepository<TEntity> where TEntity: class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            this.Context = context;
        }

        public TEntity Add(TEntity entity) => 
            this.Context.Set<TEntity>().Add(entity);

        public void AddRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().AddRange(entities);
        }

        public int Count(Expression<Func<TEntity, bool>> predicate) => 
            this.Context.Set<TEntity>().Count<TEntity>(predicate);

        public virtual TEntity Delete(TEntity entity) => 
            this.Context.Set<TEntity>().Remove(entity);

        public virtual void Edit(TEntity entity)
        {
            this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => 
            this.Context.Set<TEntity>().Where<TEntity>(predicate);

        public TEntity Get(int id)
        {
            object[] keyValues = new object[] { id };
            return this.Context.Set<TEntity>().Find(keyValues);
        }

        public IEnumerable<TEntity> GetAll() => 
            this.Context.Set<TEntity>().ToList<TEntity>();

        public void RemoveRange(IEnumerable<TEntity> entities)
        {
            this.Context.Set<TEntity>().RemoveRange(entities);
        }

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> predicate) => 
            this.Context.Set<TEntity>().SingleOrDefault<TEntity>(predicate);
    }
}

