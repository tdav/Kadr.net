using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Kadr.Models.Entity
{
    public class Repository<TEntity> : IRepositoy<TEntity> where TEntity : class
    {
        protected readonly KadrDbContext Context;

        public Repository(KadrDbContext context)
        {
            this.Context = context;
        }

        public TEntity Get(object id)
        {
            return Context.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            Context.Set<TEntity>().Load();
            return Context.Set<TEntity>().AsNoTracking();
        }

        public IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate);

        public IEnumerable<TEntity> NoTracking() => Context.Set<TEntity>().AsNoTracking();


        public IEnumerable<TEntity> NoTracking(int TakeCount)
        {
            return Context.Set<TEntity>().AsNoTracking().Take(TakeCount);
        }

        public IEnumerable<TEntity> FindNoTracking(Expression<Func<TEntity, bool>> predicate) => Context.Set<TEntity>().Where(predicate).AsNoTracking();

        public void Add(TEntity item)
        {
            Context.Set<TEntity>().Add(item);
        }

        //public void AddRange(IEnumerable<TEntity> items)
        //{
        //    Context.Set<TEntity>().AddRange(items);
        //}

        public void Remove(object id)
        {
            TEntity entity = Context.Set<TEntity>().Find(id);
            if (entity == null) return;

            if (Context.Entry<TEntity>(entity).State == System.Data.Entity.EntityState.Detached)
            {
                Context.Set<TEntity>().Attach(entity);
            }
            Context.Set<TEntity>().Remove(entity);
        }

        //public void RemoveRange(IEnumerable<TEntity> items)
        //{
        //    Context.Set<TEntity>().RemoveRange(items);
        //}

        public void Update(TEntity item, object id)
        {
            Context.Entry(Context.Set<TEntity>().Find(id)).CurrentValues.SetValues(item);
        }

        public void Update(TEntity item)
        {
            Context.Entry(item).State = System.Data.Entity.EntityState.Modified;
            //Context.Entry(Context.Set<TEntity>()).CurrentValues.SetValues(item);
        }

    }
}
