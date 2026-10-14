using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities {

    /// <summary>
    /// Represents a reservation entity with a list of books.
    /// </summary>
    public class Reservation {

        /// <summary>
        /// Gets or sets the id of the reservation
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Gets or sets the list of books associated with the reservation. This property is optional and can be null.
        /// </summary>
        public List<Book>? Books { get; set; }

        /// <summary>
        /// Gets or sets the user associated with the reservation. This property is optional and can be null.
        /// </summary>
        public User? User { get; set; }

        /// <summary>
        /// Gets or sets the user ID associated with the reservation. This property is required.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the start date of the reservation. This property is required.
        /// </summary>
        public DateOnly StartDate { get; set; }

        /// <summary>
        /// Gets or sets the end date of the reservation. This property is required.
        /// </summary>
        public DateOnly EndDate { get; set; }

        /// <summary>
        /// Creates a new reservation with the specified user ID, list of books, and number of days to reserve.
        /// </summary>
        /// <param name="userId">The ID of the user making the reservation.</param>
        /// <param name="books">The list of books to reserve.</param>
        /// <param name="daysToReserve">The number of days to reserve the books.</param>
        /// <returns>A new reservation instance.</returns>
        /// <exception cref="ArgumentException">An argument is invalid.</exception>
        public static Reservation Create(
            int userId,
            List<Book> books,
            int daysToReserve
        ) {

            if (userId <= 0) {
                throw new ArgumentException("User ID must be greater than zero.", nameof(userId));
            }

            if (daysToReserve <= 0) {
                throw new ArgumentException("Days to reserve must be greater than zero.", nameof(daysToReserve));
            }

            return new Reservation {
                UserId = userId,
                Books = books,
                StartDate = DateOnly.FromDateTime(DateTime.Now),
                EndDate = DateOnly.FromDateTime(DateTime.Now.AddDays(daysToReserve))
            };
        }
    }
}
