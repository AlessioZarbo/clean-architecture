using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Author {

    /// <summary>
    /// Represents a data transfer object (DTO) for creating an author, containing properties such as Id, Name, and Surname.
    /// </summary>
    public class AuthorCreateDto {

        /// <summary>
        /// Gets or sets the ID of the author.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the author. This property is required and cannot be null or empty.
        /// </summary>
        public required string Name { get; set; }

        /// <summary>
        /// Gets or sets the surname of the author. This property is required and cannot be null or empty.
        /// </summary>
        public required string Surname { get; set; }
    }
}
