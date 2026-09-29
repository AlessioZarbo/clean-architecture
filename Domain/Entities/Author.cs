using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {

    /// <summary>
    /// Represents an author entity. This class can be expanded with properties such as Name, Biography, etc., as needed.
    /// </summary>
    public class Author {

        /// <summary>
        /// Gets or sets the ID of the author.
        /// </summary>
        public int AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the name of the author. This property is required.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname of the author. This property is required.
        /// </summary>
        public required string Surname { get; set; }

        /// <summary>
        /// Gets or sets the list of books associated with the author. This property is initialized to an empty list to avoid null reference issues.
        /// </summary>
        public List<Book>? Books { get; set; }

        /// <summary>
        /// Creates a new instance of the Author class with the specified properties.
        /// </summary>
        /// <param name="name">The name of the author.</param>
        /// <param name="surname">The surname of the author.</param>
        /// <returns>A new Author instance.</returns>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        public static Author Create(
            string name,
            string surname
        ) {
            if (string.IsNullOrWhiteSpace(name)) {
                throw new ArgumentException("Name cannot be null or empty.", nameof(name));
            }
            if (string.IsNullOrWhiteSpace(surname)) {
                throw new ArgumentException("Surname cannot be null or empty.", nameof(surname));
            }
            return new Author {
                Name = name,
                Surname = surname
            };
        }
    }
}
