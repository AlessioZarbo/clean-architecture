using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Perstistence {
    public class UserRepository : IUserRepository {
        public Task<User> CreateAsync(User entity) {
            throw new NotImplementedException();
        }

        public Task<User> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<User>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<User> UpdateAsync(int id, User entity) {
            throw new NotImplementedException();
        }
    }
}
