using Application.DTO.Author;
using Application.DTO.Book;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;

namespace Application.Services {

    /// <summary>
    /// Represents a service for managing books, providing methods for creating, retrieving, updating, and deleting books.
    /// </summary>
    /// <param name="bookRepository">The repository for accessing book data.</param>
    public class BookService(IBookRepository bookRepository) : IBookService {

        /// <summary>
        /// The repository for accessing book data.
        /// </summary>
        private readonly IBookRepository _bookRepository = bookRepository;

        /// <summary>
        /// Retrieves all books from the repository and maps them to BookDto objects.
        /// </summary>
        /// <returns>The list of BookDto objects.</returns>
        /// <exception cref="Exception">The exception that is thrown when no books are found.</exception>
        public async Task<IEnumerable<BookDto>> GetAllBooksAsync() {

            var books = await _bookRepository.GetAllAsync();
            if (books == null) {
                throw new Exception("No books found.");
            }

            return books.Select(MapToDto);
        }

        /// <summary>
        /// Retrieves a book by its ID from the repository and maps it to a BookDto object.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The BookDto object.</returns>
        /// <exception cref="Exception">The exception that is thrown when the book is not found.</exception>
        public async Task<BookDto> GetBookByIdAsync(int id) {

            var book = await _bookRepository.GetByIdAsync(id);
            if (book == null) {
                throw new NotFoundException(typeof(Book), id);
            }

            return MapToDto(book);
        }

        /// <summary>
        /// Creates a new book in the repository based on the provided BookCreateDto object.
        /// </summary>
        /// <param name="bookDto">The BookCreateDto object containing the book's data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task CreateBookAsync(BookCreateDto bookDto) => await _bookRepository.CreateAsync(MapToEntity(bookDto));


        /// <summary>
        /// Updates an existing book in the repository based on the provided BookCreateDto object.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="bookDto">The BookCreateDto object containing the updated book's data.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task UpdateBookAsync(int id, BookCreateDto bookDto) => await _bookRepository.UpdateAsync(id, MapToEntity(bookDto));

        /// <summary>
        /// Deletes a book from the repository by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public async Task DeleteBookAsync(int id) => await _bookRepository.DeleteAsync(id);

        /// <summary>
        /// Maps a Book entity to a BookDto.
        /// </summary>
        /// <param name="book">The Book entity to map.</param>
        /// <returns>The mapped BookDto.</returns>
        public static BookDto MapToDto(Book book) {

            return new BookDto {
                Id = book.BookId,
                Title = book.Title,
                AuthorId = book.AuthorId,
                Author = book.Author != null ? new AuthorDto {
                    Id = book.Author.AuthorId,
                    Name = book.Author.Name,
                    Surname = book.Author.Surname,
                } : null,
                PublicationYear = book.PublicationYear ?? null,
                IsAvailable = book.IsAvailable
            };
        }

        public static Book MapToEntity(BookCreateDto bookDto) {

            return Book.Create(
                title: bookDto.Title,
                authorId: bookDto.AuthorId,
                publicationYear: bookDto.PublicationYear ?? null,
                isAvailable: bookDto.IsAvailable
            );
        }
    }
}
