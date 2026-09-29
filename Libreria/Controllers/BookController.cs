using Application.DTO.Book;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {

    /// <summary>
    /// Controller for managing books in the library.
    /// </summary>
    /// <param name="bookService">The service for managing books.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class BookController(IBookService bookService) : ControllerBase {

        /// <summary>
        /// The service for managing books.
        /// </summary>
        private readonly IBookService _bookService = bookService;

        /// <summary>
        /// Gets all books in the library.
        /// </summary>
        /// <returns>The list of all books in the library.</returns>
        [HttpGet]
        public async Task<IActionResult> GetBooks() {

            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        /// <summary>
        /// Gets a specific book by its ID.
        /// </summary>
        /// <param name="id">The ID of the book to retrieve.</param>
        /// <returns>The book with the specified ID, or null if not found.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetBook(int id) {

            var book = await _bookService.GetBookByIdAsync(id);
            if (book == null) {
                return NotFound();
            }
            return Ok(book);
        }

        /// <summary>
        /// Creates a new book in the library.
        /// </summary>
        /// <param name="bookDto">The data for the new book.</param>
        /// <returns>The created book.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateBook([FromBody] BookCreateDto bookDto) {

            var createdBook = await _bookService.CreateBookAsync(bookDto);
            return Ok(createdBook);
        }

        /// <summary>
        /// Updates an existing book in the library.
        /// </summary>
        /// <param name="id">The ID of the book to update.</param>
        /// <param name="bookDto">The updated data for the book.</param>
        /// <returns>The updated book.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateBook(int id, [FromBody] BookCreateDto bookDto) {

            var updatedBook = await _bookService.UpdateBookAsync(id, bookDto);
            return Ok(updatedBook);
        }

        /// <summary>
        /// Deletes a book from the library.
        /// </summary>
        /// <param name="id">The ID of the book to delete.</param>
        /// <returns>The deleted book.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteBook(int id) {

            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
