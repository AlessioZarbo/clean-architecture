using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.User {

    /// <summary>
    /// Represents a data transfer object (DTO) for a user, containing properties such as Id, Username, and Email.
    /// </summary>
    public class UserDto {

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the username of the user. This property is required and cannot be null or empty.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the email of the user.
        /// </summary>
        public required string Email { get; set; }
    }
}
