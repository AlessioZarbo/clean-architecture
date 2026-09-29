using Application.DTO.Author;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces {

    /// <summary>
    /// Represents a service interface for managing authors, providing methods for retrieving, creating, updating, and deleting author data.
    /// </summary>
    public interface IAuthorService {

        /// <summary>
        /// Retrieves a collection of all authors asynchronously.
        /// </summary>
        /// <returns>The collection of all authors.</returns>
        Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync();

        /// <summary>
        /// Retrieves an author by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the author.</param>
        /// <returns>The author with the specified ID, or null if not found.</returns>
        Task<AuthorDto> GetAuthorByIdAsync(int id);

        /// <summary>
        /// Creates a new author asynchronously.
        /// </summary>
        /// <param name="authorDto">The data transfer object containing the author's information.</param>
        /// <returns>The created author.</returns>
        Task<AuthorCreateDto> CreateAuthorAsync(AuthorCreateDto authorDto);

        /// <summary>
        /// Updates an existing author asynchronously.
        /// </summary>
        /// <param name="id">The ID of the author to update.</param>
        /// <param name="authorDto">The data transfer object containing the updated author's information.</param>
        /// <returns>The updated author.</returns>
        Task<AuthorDto> UpdateAuthorAsync(int id, AuthorCreateDto authorDto);

        /// <summary>
        /// Deletes an author by their unique identifier asynchronously.
        /// </summary>
        /// <param name="id">The unique identifier of the author to delete.</param>
        /// <returns>The deleted author.</returns>
        Task<AuthorDto> DeleteAuthorAsync(int id);
    }
}
