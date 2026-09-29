using Application.DTO.Reservation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Interfaces {
    /// <summary>
    /// Defines the interface for a reservation service.
    /// </summary>
    public interface IReservationService {

        /// <summary>
        /// Gets all reservations asynchronously.
        /// </summary>
        /// <returns>The list of reservations.</returns>
        Task<IEnumerable<ReservationDto>> GetAllReservationsAsync();

        /// <summary>
        /// Gets a reservation by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the reservation to retrieve.</param>
        /// <returns>The reservation with the specified ID, or null if not found.</returns>
        Task<ReservationDto> GetReservationByIdAsync(int id);

        /// <summary>
        /// Creates a new reservation asynchronously.
        /// </summary>
        /// <param name="reservationDto">The data transfer object containing the reservation details.</param>
        /// <returns>The created reservation.</returns>
        Task<ReservationDto> CreateReservationAsync(ReservationCreateDto reservationDto);

        /// <summary>
        /// Updates an existing reservation asynchronously.
        /// </summary>
        /// <param name="id">The ID of the reservation to update.</param>
        /// <param name="reservationDto">The data transfer object containing the updated reservation details.</param>
        /// <returns>The updated reservation.</returns>
        Task<ReservationDto> UpdateReservationAsync(int id, ReservationCreateDto reservationDto);

        /// <summary>
        /// Deletes a reservation by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the reservation to delete.</param>
        /// <returns>The deleted reservation.</returns>
        Task<ReservationDto> DeleteReservationAsync(int id);
    }
}
