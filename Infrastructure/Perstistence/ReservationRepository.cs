using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Perstistence {
    public class ReservationRepository : IReservationRepository {
        public Task<Reservation> CreateAsync(Reservation entity) {
            throw new NotImplementedException();
        }

        public Task<Reservation> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Reservation>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Reservation> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Reservation> UpdateAsync(int id, Reservation entity) {
            throw new NotImplementedException();
        }
    }
}
