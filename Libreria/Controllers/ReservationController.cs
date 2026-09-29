using Application.DTO.Reservation;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController(IReservationService reservationService) : ControllerBase {

        private readonly IReservationService _reservationService = reservationService;

        /// <summary>
        /// Gets all reservations in the library.
        /// </summary>
        /// <returns>The list of all reservations.</returns>
        [HttpGet]
        public async Task<IActionResult> GetReservations() {

            var reservations = await _reservationService.GetAllReservationsAsync();
            return Ok(reservations);
        }

        /// <summary>
        /// Gets a specific reservation by its ID.
        /// </summary>
        /// <param name="id">The ID of the reservation to get.</param>
        /// <returns>The reservation with the specified ID, or null if not found.</returns>
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetReservation(int id) {

            var reservation = await _reservationService.GetReservationByIdAsync(id);
            if (reservation == null) {
                return NotFound();
            }

            return Ok(reservation);
        }

        /// <summary>
        /// Creates a new reservation in the library.
        /// </summary>
        /// <param name="reservationDto">The reservation data to create.</param>
        /// <returns>The created reservation.</returns>
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationCreateDto reservationDto) {

            var createdReservation = await _reservationService.CreateReservationAsync(reservationDto);
            return Ok(createdReservation);
        }

        /// <summary>
        /// Updates an existing reservation by its ID.
        /// </summary>
        /// <param name="id">The ID of the reservation to update.</param>
        /// <param name="reservationDto">The updated reservation data.</param>
        /// <returns>The updated reservation.</returns>
        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateReservation(int id, [FromBody] ReservationCreateDto reservationDto) {

            var updatedReservation = await _reservationService.UpdateReservationAsync(id, reservationDto);
            return Ok(updatedReservation);
        }

        /// <summary>
        /// Deletes a specific reservation by its ID.
        /// </summary>
        /// <param name="id">The ID of the reservation to delete.</param>
        /// <returns>The deleted reservation.</returns>
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteReservation(int id) {

            var deletedReservation = await _reservationService.DeleteReservationAsync(id);
            return NoContent();
        }
    }
}
