using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Linq.Expressions;


namespace Asbt.Data
{    
    public class Repository<TEntity> : IDisposable where TEntity : class
    {
        public Entities1 context;
        internal DbSet<TEntity> dbSet;

        public Repository()
        {
            this.context = new Entities1();
            this.context.Configuration.ProxyCreationEnabled = false;
            this.context.Configuration.LazyLoadingEnabled = false;
            this.dbSet = context.Set<TEntity>();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>,
                                                 IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }


        public IQueryable<TBMAIN> GetAll()
        {

            var v = context.TBMAINs
                  .Include(x => x.TBATESTATIYAs)
                  .Include(x => x.TBFOTOes)
                  .Include(x => x.TBGOSNAGRADIs)
                  .Include(x => x.TBPOVISHKVALs)
                  .Include(x => x.TBMESTORABs)
                  .Include(x => x.TBQARINDOSHes)

                  .Include(x => x.TBUNIVERs);
            return v;
        }

        public virtual TEntity GetSingle(Func<TEntity, bool> where,
             params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            TEntity item = null;

            IQueryable<TEntity> dbQuery = context.Set<TEntity>();

            //Apply eager loading
            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            item = dbQuery
                .FirstOrDefault(where); //Apply where clause

            return item;
        }



        public IList<TEntity> GetList(Func<TEntity, bool> where,
            params Expression<Func<TEntity, object>>[] navigationProperties)
        {
            List<TEntity> list;
            IQueryable<TEntity> dbQuery = context.Set<TEntity>();

            foreach (Expression<Func<TEntity, object>> navigationProperty in navigationProperties)
                dbQuery = dbQuery.Include<TEntity, object>(navigationProperty);

            list = dbQuery.AsNoTracking().Where(where).ToList<TEntity>();

            return list;
        }

        public virtual TEntity GetByID(object id)
        {
            return dbSet.Find(id);
        }

        public virtual void SetModifiedState(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified; 
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = dbSet.Find(id);
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entityToDelete)
        {
            if (context.Entry(entityToDelete).State == EntityState.Detached)
            {
                dbSet.Attach(entityToDelete);
            }
            dbSet.Remove(entityToDelete);
        }

        public virtual void Update(TEntity entityToUpdate)
        {
            dbSet.Attach(entityToUpdate);
            context.Entry(entityToUpdate).State = EntityState.Modified;
        }

        public bool Save()
        {
            return context.SaveChanges() > 0;
        }
    }

}
