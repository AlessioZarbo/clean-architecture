using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.User {

    /// <summary>
    /// Represents a data transfer object (DTO) for creating a user, containing properties such as Username, Email, and Password.
    /// </summary>
    public class UserCreateDto {

        /// <summary>
        /// Gets or sets the username of the user. This property is required and cannot be null or empty.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the email of the user. This property is required and cannot be null or empty.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user. This property is required and cannot be null or empty.
        /// </summary>
        public required string Password { get; set; }
    }
}
