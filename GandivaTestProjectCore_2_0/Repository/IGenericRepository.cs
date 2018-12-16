using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject
{
    public interface IGenericRepository<TEntity, in TKey> where TEntity : class
    {
        TEntity FindById(TKey id);
        IEnumerable<TEntity> Get(Func<TEntity, bool> predicate);
        void Remove(TEntity item);
        void Update(TKey key, TEntity item);
        void SaveChanges();
    }
}
