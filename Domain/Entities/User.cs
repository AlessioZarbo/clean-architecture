using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {

    /// <summary>
    /// Represents a user entity. This class can be expanded with properties such as Username, Email, etc., as needed.
    /// </summary>
    public class User {

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username of the user. This property is required.
        /// </summary>
        public required string Username { get; set; }

        /// <summary>
        /// Gets or sets the email of the user. This property is required.
        /// </summary>
        public required string Email { get; set; }

        /// <summary>
        /// Gets or sets the password of the user. This property is required.
        /// </summary>
        public required string Password { get; set; }

        /// <summary>
        /// Gets or sets the list of reservations associated with the user. This property is optional and can be null.
        /// </summary>
        public List<Reservation>? Reservations { get; set; }

        /// <summary>
        /// Creates a new user with the specified username, email, and password.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="email">The email of the user.</param>
        /// <param name="password">The password of the user.</param>
        /// <returns>A new user instance.</returns>
        public static User Create(
            string username,
            string email,
            string password
        ) {

            if (string.IsNullOrWhiteSpace(username)) {
                throw new ArgumentException("Username cannot be null or empty.", nameof(username));
            }

            if (string.IsNullOrWhiteSpace(email)) {
                throw new ArgumentException("Email cannot be null or empty.", nameof(email));
            }

            if (string.IsNullOrWhiteSpace(password)) {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }

            return new User {
                Username = username,
                Email = email,
                Password = password
            };
        }
    }
}
