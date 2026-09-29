using Application.DTO.Author;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {

    /// <summary>
    /// Controller for managing authors in the library.
    /// </summary>
    /// <param name="authorService">The service used to manage authors.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController(IAuthorService authorService) : ControllerBase {

        private readonly IAuthorService _authorService = authorService;

        /// <summary>
        /// Gets all authors in the library.
        /// </summary>
        /// <returns>The list of all authors.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAuthors() {

            var authors = await _authorService.GetAllAuthorsAsync();
            return Ok(authors);
        }

        /// <summary>
        /// Gets a specific author by their ID.
        /// </summary>
        /// <param name="id">The ID of the author to get.</param>
        /// <returns>The author with the specified ID, or null if not found.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAuthor(int id) {

            var author = await _authorService.GetAuthorByIdAsync(id);
            if (author == null) {
                return NotFound();
            }

            return Ok(author);
        }
        /// <summary>
        /// Creates a new author in the library.
        /// </summary>
        /// <param name="authorDto">The author data to create.</param>
        /// <returns>The created author.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateAuthor([FromBody] AuthorCreateDto authorDto) {

            var createdAuthor = await _authorService.CreateAuthorAsync(authorDto);
            return Ok(createdAuthor);
        }

        /// <summary>
        /// Updates an existing author in the library.
        /// </summary>
        /// <param name="id">The ID of the author to update.</param>
        /// <param name="authorDto">The updated author data.</param>
        /// <returns>The updated author.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAuthor(int id, [FromBody] AuthorCreateDto authorDto) {

            var updatedAuthor = await _authorService.UpdateAuthorAsync(id, authorDto);
            return Ok(updatedAuthor);
        }

        /// <summary>
        /// Deletes an existing author from the library.
        /// </summary>
        /// <param name="id">The ID of the author to delete.</param>
        /// <returns>The result of the deletion operation.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAuthor(int id) {

            var deleted = await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
