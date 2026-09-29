using Application.DTO.Book;
using Application.DTO.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTO.Reservation {

    /// <summary>
    /// Represents a data transfer object (DTO) for a reservation, containing properties such as Id, a list of books, and the user who made the reservation.
    /// </summary>
    public class ReservationDto {

        /// <summary>
        /// Gets or sets the ID of the reservation.
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the list of books associated with the reservation. This property is required and cannot be null.
        /// </summary>
        public required List<BookDto> Books { get; set; }

        /// <summary>
        /// Gets or sets the user who made the reservation. This property is required and cannot be null.
        /// </summary>
        public required UserDto User { get; set; }

        /// <summary>
        /// Gets or sets the start date of the reservation. This property is required.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the reservation. This property is required.
        /// </summary>
        public DateOnly EndDate { get; set; }
    }
}
