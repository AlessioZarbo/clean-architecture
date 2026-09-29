using Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces {
    /// <summary>
    /// Defines the interface for the user service.
    /// </summary>
    public interface IUserService {

        /// <summary>
        /// Gets all users asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of UserDto objects.</returns>
        Task<IEnumerable<UserDto>> GetAllUsersAsync();

        /// <summary>
        /// Gets a user by their ID asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user to retrieve.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the UserDto object for the specified ID.</returns>
        Task<UserDto> GetUserByIdAsync(int userId);

        /// <summary>
        /// Creates a new user asynchronously.
        /// </summary>
        /// <param name="userCreateDto">The UserCreateDto object containing the user's data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the created UserDto object.</returns>
        Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto);

        /// <summary>
        /// Updates an existing user asynchronously.
        /// </summary>
        /// <param name="id">The ID of the user to update.</param>
        /// <param name="userCreateDto">The UserCreateDto object containing the updated user's data.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the updated UserDto object.</returns>
        Task<UserDto> UpdateUserAsync(int id, UserCreateDto userCreateDto);

        /// <summary>
        /// Deletes a user by their ID asynchronously.
        /// </summary>
        /// <param name="userId">The ID of the user to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the deleted UserDto object.</returns>
        Task<UserDto> DeleteUserAsync(int userId);
    }
}
