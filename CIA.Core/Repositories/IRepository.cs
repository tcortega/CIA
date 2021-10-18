using CIA.Core.Entities;
using System.Collections.Generic;
using System.Linq;

namespace CIA.Core.Repositories
{
    /// <summary>
    /// Stores data.
    /// </summary>
    /// <typeparam name="T">The type of data to store</typeparam>
    public interface IRepository<T> where T : Entity
    {
        // ------
        // CREATE
        // ------

        /// <summary>
        /// Adds an <paramref name="entity"/> to the repository.
        /// </summary>
        void Add(T entity);

        /// <summary>
        /// Adds multiple <paramref name="entities"/> to the repository.
        /// </summary>
        void Add(IEnumerable<T> entity);

        // ----
        // READ
        // ----

        /// <summary>
        /// Gets an entity by <paramref name="id">.
        /// </summary>
        T Get(int id);

        /// <summary>
        /// Gets an <see cref="IQueryable{T}"/> of all entities in the repository for further filtering.
        /// </summary>
        IQueryable<T> GetAll();

        // ------
        // UPDATE
        // ------

        /// <summary>
        /// Updates an <paramref name="entity"/> in the repository.
        /// </summary>
        void Update(T entity);

        /// <summary>
        /// Updates multiple <paramref name="entities"/> in the repository.
        /// </summary>
        void Update(IEnumerable<T> entities);

        // ------
        // DELETE
        // ------

        /// <summary>
        /// Deletes an <paramref name="entity"/> from the repository.
        /// </summary>
        void Delete(T entity);

        /// <summary>
        /// Deletes multiple <paramref name="entities"/> from the repository.
        /// </summary>
        void Delete(IEnumerable<T> entities);

        /// <summary>
        /// Attaches to a given entity so that EF doesn't try to create a new one
        /// in a one to many relationship.
        /// </summary>>
        public void Attach<TEntity>(TEntity entity) where TEntity : Entity;

        public void Detach<TEntity>(TEntity entity) where TEntity : Entity;
    }
}