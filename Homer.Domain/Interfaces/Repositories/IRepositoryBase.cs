
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Homer.Domain.Interfaces.Repositories
{
    /// <summary>
    /// Repository base class.
    /// </summary>
    /// <typeparam name="T">Repository for entity object.</typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Adds an entity async.
        /// </summary>
        /// <typeparam name="Entity">The entity to be added.</typeparam>
        /// <param name="entity">The entity to be added.</param>
        void AddAsync(T entity);

        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <typeparam name="Entity">The entity to be added.</typeparam>
        /// <param name="entity">The entity to be added.</param>
        void Add(T entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <typeparam name="Entity">The entity to be removed.</typeparam>
        /// <param name="entity">The entity to be removed.</param>
        void Remove(T entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <typeparam name="Entity">The entity to be updated.</typeparam>
        /// <param name="entity">The entity to be updated.</param>
        void Update(T entity);

        /// <summary>
        /// Perform save data to database.
        /// </summary>
        void SaveChange();

        /// <summary>
        /// Gets <see cref="IEnumerable{T}"/> list of entities.
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetAll();

        /// <summary>
        /// Gets an entity by Id.
        /// </summary>
        /// <param name="id">Entity Id</param>
        /// <returns>entity object.</returns>
        Task<T?> GetEntity(int id);

        /// <summary>
        /// Perform async save data to database.
        /// </summary>
        void SaveChangeAsync();
    }
}
