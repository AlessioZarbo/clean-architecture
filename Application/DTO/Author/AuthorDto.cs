using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Author {

    /// <summary>
    /// Represents a data transfer object (DTO) for an author, containing properties such as Id, Name, Surname, and a list of book titles associated with the author.
    /// </summary>
    public class AuthorDto {

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

        /// <summary>
        /// Gets or sets the list of book titles associated with the author. This property is optional and can be null.
        /// </summary>
        public List<string>? Titles { get; set; }
    }
}
