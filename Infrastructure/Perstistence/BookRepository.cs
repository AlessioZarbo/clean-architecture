using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Perstistence {

    /// <summary>
    /// Repository class for managing Book entities in the database.
    /// </summary>
    /// <param name="ctx">The database context.</param>
    public class BookRepository(LibraryDbContext ctx) : IBookRepository {

        /// <summary>
        /// The database context used for accessing the database.
        /// </summary>
        private readonly LibraryDbContext _ctx = ctx;

        /// <summary>
        /// Retrieves all books from the database, including their associated authors.
        /// </summary>
        /// <returns>The list of all books.</returns>
        public async Task<IEnumerable<Book>> GetAllAsync() {

            return await _ctx.Books
                .Include(b => b.Author)
                .ToListAsync();
        }

        /// <summary>
        /// Retrieves a book by its ID from the database, including its associated author.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID.</returns>
        /// <exception cref="KeyNotFoundException">Thrown when a book with the specified ID is not found.</exception>
        public async Task<Book> GetByIdAsync(int id) {
            
             return await _ctx.Books
                .Include(b => b.Author)
                .FirstOrDefaultAsync(b => b.BookId == id);
        }

        public async Task CreateAsync(Book entity) {

            await _ctx.Books.AddAsync(entity);
        }

        /// <summary>
        /// Updates an existing book in the database with the provided entity.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="entity">The updated book entity.</param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, Book entity) {
            var book = await GetByIdAsync(id);
            book = entity;
        }

        /// <summary>
        /// Deletes a book from the database by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns></returns>
        public async Task DeleteAsync(int id) {

            var book = await GetByIdAsync(id);
            _ctx.Books.Remove(book);
        }
    }
}
