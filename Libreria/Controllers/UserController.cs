using Application.DTO.User;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {

    /// <summary>
    /// Controller for managing users in the library.
    /// </summary>
    /// <param name="userService">The service used to manage users.</param>
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase {

        /// <summary>
        /// The service used to manage users.
        /// </summary>
        private readonly IUserService _userService = userService;

        /// <summary>
        /// Gets all users in the library.
        /// </summary>
        /// <returns>The list of all users.</returns>
        [HttpGet]
        public async Task<IActionResult> GetAllUsers() {

            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }

        /// <summary>
        /// Gets a user by their ID.
        /// </summary>
        /// <param name="id">The ID of the user to get.</param>
        /// <returns>The user with the specified ID, or null if not found.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetUser(int id) {

            var user = await _userService.GetUserByIdAsync(id);
            if (user == null) {
                return NotFound();
            }

            return Ok(user);
        }

        /// <summary>
        /// Creates a new user in the library.
        /// </summary>
        /// <param name="userDto">The user data to create.</param>
        /// <returns>The created user.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserCreateDto userDto) {
            
            var createdUser = await _userService.CreateUserAsync(userDto);
            return Ok(createdUser);
        }

        /// <summary>
        /// Updates an existing user in the library.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userDto">The updated user data.</param>
        /// <returns>The updated user, or null if not found.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserCreateDto userDto) {
            
            var updatedUser = await _userService.UpdateUserAsync(id, userDto);
            if (updatedUser == null) {
                return NotFound();
            }

            return Ok(updatedUser);
        }

        /// <summary>
        /// Deletes a user from the library.
        /// </summary>
        /// <param name="id">The ID of the user to delete.</param>
        /// <returns>The result of the deletion operation.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteUser(int id) {

            var deleted = await _userService.DeleteUserAsync(id);
            return NoContent();
        }
    }
}
