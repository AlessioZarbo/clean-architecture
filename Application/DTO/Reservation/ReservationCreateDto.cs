using Application.DTO.Book;
using Application.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Reservation {
    public class ReservationCreateDto {

        /// <summary>
        /// Gets or sets the list of books associated with the reservation. This property is required and cannot be null.
        /// </summary>
        public required List<BookDto> Books { get; set; }

        /// <summary>
        /// Gets or sets the user who made the reservation. This property is required and cannot be null.
        /// </summary>
        public required UserDto User { get; set; }

        /// <summary>
        /// Gets or sets the number of days to reserve the books. This property is required and must be greater than zero.
        /// </summary>
        public int DaysToReserve { get; set; }
    }
}
