using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Kadr.Models.Entity
{
    public interface IRepositoy<TEntity> where TEntity : class
    {
        TEntity Get(object id); 
        IEnumerable<TEntity> GetAll();
        IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate);
        IEnumerable<TEntity> NoTracking();
        IEnumerable<TEntity> NoTracking(int TakeCount);
        IEnumerable<TEntity> FindNoTracking(Expression<Func<TEntity, bool>> predicate);
                
        void Add(TEntity item);
      //  void AddRange(IEnumerable<TEntity> items);

        void Remove(object id);
      //  void RemoveRange(IEnumerable<TEntity> items);

        void Update(TEntity item, object id);
        void Update(TEntity item);

      //  Task Merge(IEnumerable<TEntity> list);
    }
}
