using CIA.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CIA.Core.Repositories
{
    /// <summary>
    /// Stores data to a database.
    /// </summary>
    /// <typeparam name="T">The type of data to store</typeparam>
    public class DbRepository<T> : IRepository<T> where T : Entity
    {
        protected readonly ApplicationDbContext _context;

        public DbRepository(ApplicationDbContext ctx)
        {
            _context = ctx;
        }

        /// <inheritdoc/>
        public virtual void Add(T entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual void Add(IEnumerable<T> entities)
        {
            _context.AddRange(entities);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual void Delete(T entity)
        {
            _context.Remove(entity);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual void Delete(IEnumerable<T> entities)
        {
            _context.RemoveRange(entities);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual T Get(int id)
        {
            return GetAll().FirstOrDefault(e => e.Id == id);
        }

        /// <inheritdoc/>
        public virtual IQueryable<T> GetAll()
            => _context.Set<T>();

        /// <inheritdoc/>
        public virtual void Update(T entity)
        {
            _context.Update(entity);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public virtual void Update(IEnumerable<T> entities)
        {
            _context.UpdateRange(entities);
            _context.SaveChanges();
        }

        /// <inheritdoc/>
        public void Attach<TEntity>(TEntity entity) where TEntity : Entity => _context.Attach(entity);
    }
}
