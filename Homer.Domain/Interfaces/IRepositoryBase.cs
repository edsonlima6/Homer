
using System.ComponentModel;

namespace Homer.Domain.Interfaces
{
    /// <summary>
    /// Repository base class.
    /// </summary>
    /// <typeparam name="T">Repository for entity object.</typeparam>
    public interface IRepositoryBase<T> where T : class
    {
        /// <summary>
        /// Adds an entity.
        /// </summary>
        /// <typeparam name="Entity">The entity to be added.</typeparam>
        /// <param name="entity">The entity to be added.</param>
        void Add<Entity>(Entity entity);

        /// <summary>
        /// Removes an entity.
        /// </summary>
        /// <typeparam name="Entity">The entity to be removed.</typeparam>
        /// <param name="entity">The entity to be removed.</param>
        void Remove<Entity>(Entity entity);

        /// <summary>
        /// Updates an entity.
        /// </summary>
        /// <typeparam name="Entity">The entity to be updated.</typeparam>
        /// <param name="entity">The entity to be updated.</param>
        void Update<Entity>(Entity entity);
    }
}
