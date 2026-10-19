using Application.DTO.Author;
using Application.DTO.Book;
using Application.Exceptions;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Application.Services {

    /// <summary>
    /// Represents a service for managing books, providing methods for creating, retrieving, updating, and deleting books.
    /// </summary>
    /// <param name="bookRepository">The repository for accessing book data.</param>
    /// <param name="logger">The logger for logging information and errors.</param>
    /// <param name="configuration">The configuration for the application.</param>
    public class BookService(IBookRepository bookRepository, ILogger<BookService> logger, IConfiguration configuration) : IBookService {

        /// <summary>
        /// The repository for accessing book data.
        /// </summary>
        private readonly IBookRepository _bookRepository = bookRepository;

        /// <summary>
        /// The logger for logging information and errors.
        /// </summary>
        private readonly ILogger<BookService> _logger =  logger;

        /// <summary>
        /// The configuration for the application.
        /// </summary>
        private readonly int _defaultPageSize = configuration.GetValue<int>("PaginationRules:DefaultPageSize");

        /// <summary>
        /// The default page number for pagination, retrieved from the application configuration.
        /// </summary>
        private readonly int _defaultPageNumber = configuration.GetValue<int>("PaginationRules:DefaultPageNumber");

        /// <summary>
        /// The minimum page size for pagination, retrieved from the application configuration.
        /// </summary>
        private readonly int _minPageSize = configuration.GetValue<int>("PaginationRules:MinPageSize");

        /// <summary>
        /// The maximum page size for pagination, retrieved from the application configuration.
        /// </summary>
        private readonly int _maxPageSize = configuration.GetValue<int>("PaginationRules:MaxPageSize");

        /// <summary>
        /// Retrieves all books from the repository and maps them to BookDto objects.
        /// </summary>
        /// <returns>The list of BookDto objects.</returns>
        /// <exception cref="Exception">The exception that is thrown when no books are found.</exception>
        public async Task<IEnumerable<BookDto>> GetAllBooksAsync() {

            _logger.LogInformation("Retrieving all books.");
            _logger.LogDebug("Retrieving all books from the database.");
            var books = await _bookRepository.GetAllAsync();

            _logger.LogInformation("All books retrieved.");
            _logger.LogDebug("Mapped books to DTOs.");
            return books == null ? throw new Exception("No books found.") : books.Select(MapToDto);
        }

        /// <summary>
        /// Retrieves all books from the repository with pagination and maps them to BookDto objects.
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        /// <exception cref="PaginationException"></exception>
        public async Task<IEnumerable<BookDto>> GetAllPaginatedAsync(int? page, int? pageSize) {

            // Se nulli li setto tramite valore di configurazione
            page ??= _defaultPageNumber;
            pageSize ??= _defaultPageSize;

            if (page < 1)
                throw new PaginationException(page);

            if (pageSize < _minPageSize || pageSize > _maxPageSize)
                throw new PaginationException(pageSize, _minPageSize, _maxPageSize);

            return (await _bookRepository.GetAllPaginatedAsync(page.Value, pageSize.Value)).Select(MapToDto);
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
