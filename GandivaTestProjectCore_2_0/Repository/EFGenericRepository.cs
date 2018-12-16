using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GandivaTestProject
{
    public class EFGenericRepository<TEntity> : IGenericRepository<TEntity, int>
        where TEntity : class
    {
        protected TaskManagerDbContext _context;
        protected DbSet<TEntity> _dbSet;

        public EFGenericRepository(IDbContextProvider contextProvider)
        {
            _context = contextProvider.GetContext();
            _dbSet = _context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Func<TEntity, bool> predicate)
        {
            return _dbSet.AsNoTracking().Where(predicate).ToList();
        }
        public virtual TEntity FindById(int id)
        {
            return _dbSet.Find(id);
        }
        public virtual void Update(int id, TEntity item)
        {
            var myEntity = _context.Entry(item);
            myEntity.State = EntityState.Modified;
            _context.SaveChanges();
        }

        public virtual void Remove(TEntity item)
        {
            //_dbSet.Remove(item);
            //_context.SaveChanges();
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public void AddRange(params TEntity[] items)
        {
            _dbSet.AddRange(items);
            _context.SaveChanges();
        }
    }
}
