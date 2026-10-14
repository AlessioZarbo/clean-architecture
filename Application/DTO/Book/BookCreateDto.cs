using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Book {

    /// <summary>
    /// Represents a data transfer object (DTO) for creating a new book. This class contains properties that are required to create a book, including the title, author ID, publication year, and availability status.
    /// </summary>
    public class BookCreateDto {

        /// <summary>
        /// Gets or sets the title of the book. This property is required and cannot be null or empty.
        /// </summary>
        public required string Title { get; set; }

        /// <summary>
        /// Gets or sets the author ID of the book. This property is required and cannot be null.
        /// </summary>
        public int? AuthorId { get; set; }

        /// <summary>
        /// Gets or sets the publication year of the book. This property is required and cannot be null.
        /// </summary>
        public required DateOnly? PublicationYear { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether the book is available. This property is required.
        /// </summary>
        public bool IsAvailable { get; set; }
    }
}
