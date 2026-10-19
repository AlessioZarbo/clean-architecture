using Application.DTO.Book;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces {

    /// <summary>
    /// Represents a service interface for managing books, providing methods for CRUD operations such as retrieving, creating, updating, and deleting books.
    /// </summary>
    public interface IBookService {

        /// <summary>
        /// Gets all books asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of BookDto objects.</returns>
        Task<IEnumerable<BookDto>> GetAllBooksAsync();

        /// <summary>
        /// Gets all books asynchronously with pagination.
        /// </summary>
        /// <returns></returns>
        Task<BookPagedDto> GetAllPaginatedAsync(int? page, int? pageSize);

        /// <summary>
        /// Gets a book by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the BookDto object for the specified ID.</returns>
        Task<BookDto> GetBookByIdAsync(int id);

        /// <summary>
        /// Creates a new book asynchronously.
        /// </summary>
        /// <param name="bookDto">The BookCreateDto object containing the book's data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task CreateBookAsync(BookCreateDto bookDto);

        /// <summary>
        /// Updates an existing book asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="bookDto">The BookCreateDto object containing the updated book's data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task UpdateBookAsync(int id, BookCreateDto bookDto);

        /// <summary>
        /// Deletes a book by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task DeleteBookAsync(int id);
    }
}
