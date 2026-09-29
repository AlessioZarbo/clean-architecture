using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces {

    /// <summary>
    /// Defines a generic repository interface for performing CRUD operations on entities of type T.
    /// </summary>
    /// <typeparam name="T">The type of the entity.</typeparam>
    public interface IRepository<T> where T : class {

        /// <summary>
        /// Gets all entities of type T asynchronously.
        /// </summary>
        /// <returns>The list of all entities of type T.</returns>
        Task<IEnumerable<T>> GetAllAsync();

        /// <summary>
        /// Gets an entity of type T by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to retrieve.</param>
        /// <returns>The entity of type T with the specified ID, or null if not found.</returns>
        Task<T> GetByIdAsync(int id);

        /// <summary>
        /// Creates a new entity of type T asynchronously.
        /// </summary>
        /// <param name="entity">The entity to create.</param>
        /// <returns>The created entity.</returns>
        Task<T> CreateAsync(T entity);

        /// <summary>
        /// Updates an existing entity of type T asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to update.</param>
        /// <param name="entity">The updated entity.</param>
        /// <returns>The updated entity.</returns>
        Task<T> UpdateAsync(int id, T entity);

        /// <summary>
        /// Deletes an entity of type T by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the entity to delete.</param>
        /// <returns>The deleted entity.</returns>
        Task<T> DeleteAsync(int id);
    }
}
