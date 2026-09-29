using Application.DTO.Reservation;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services {
    public class ReservationService : IReservationService {
        public Task<ReservationDto> CreateReservationAsync(ReservationCreateDto reservationDto) {
            throw new NotImplementedException();
        }

        public Task<ReservationDto> DeleteReservationAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ReservationDto>> GetAllReservationsAsync() {
            throw new NotImplementedException();
        }

        public Task<ReservationDto> GetReservationByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<ReservationDto> UpdateReservationAsync(int id, ReservationCreateDto reservationDto) {
            throw new NotImplementedException();
        }
    }
}
