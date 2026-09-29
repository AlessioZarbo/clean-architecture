using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {

    /// <summary>
    /// Represents a book entity with properties for Id and Title.
    /// </summary>
    public class Book {

        /// <summary>
        /// Gets or sets the ID of the book.
        /// </summary>
        public int BookId { get; set; }

        /// <summary>
        /// Gets or sets the title of the book.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book. This property is optional and can be null.
        /// </summary>
        public Author? Author { get; set; }

        /// <summary>
        /// Gets or sets the author ID of the book. This property is optional and can be null.
        /// </summary>
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the publication year of the book. This property is required.
        /// </summary>
        public required DateOnly? PublicationYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book is available. This property is required.
        /// </summary>
        public required bool IsAvailable { get; set; }

        /// <summary>
        /// Creates a new instance of the Book class with the specified properties.
        /// </summary>
        /// <param name="title">The title of the book.</param>
        /// <param name="author">The author of the book.</param>
        /// <param name="publicationYear">The publication year of the book.</param>
        /// <param name="isAvailable">A value indicating whether the book is available.</param>
        /// <returns>A new Book instance.</returns>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        public static Book Create(
            string title,
            Author? author,
            DateOnly? publicationYear,
            bool isAvailable
        ) {

            if (string.IsNullOrWhiteSpace(title)) {
                throw new ArgumentException("Title cannot be null or empty.", nameof(title));
            }

            return new Book {
                Title = title,
                Author = author,
                PublicationYear = publicationYear,
                IsAvailable = isAvailable
            };
        }
    }
}
