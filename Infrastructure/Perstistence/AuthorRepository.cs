using Domain.Entities;
using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Perstistence {
    public class AuthorRepository : IAuthorRepository {
        public Task<Author> CreateAsync(Author entity) {
            throw new NotImplementedException();
        }

        public Task<Author> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Author>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Author> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Author> UpdateAsync(int id, Author entity) {
            throw new NotImplementedException();
        }
    }
}
