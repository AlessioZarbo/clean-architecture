using Application.DTO.Author;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Book {

    /// <summary>
    /// Represents a data transfer object (DTO) for a book, containing properties such as Id, Title, Author, PublicationYear, and IsAvailable.
    /// </summary>
    public class BookDto {

        /// <summary>
        /// Gets or sets the ID of the book.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title of the book. This property is required and cannot be null or empty.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the author of the book. This property is optional and can be null.
        /// </summary>
        public AuthorDto? Author { get; set; }

        /// <summary>
        /// Gets or sets the ID of the author of the book. This property is required and cannot be null.
        /// </summary>
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the publication year of the book. This property is required and cannot be null.
        /// </summary>
        public DateOnly? PublicationYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book is available. This property is required.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
