using Domain.Entities;
using Infrastructure.Interfaces;

namespace Infrastructure.Perstistence {
    public class BookRepository : IBookRepository {
        public Task<Book> CreateAsync(Book entity) {
            throw new NotImplementedException();
        }

        public Task<Book> DeleteAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Book>> GetAllAsync() {
            throw new NotImplementedException();
        }

        public Task<Book> GetByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<Book> UpdateAsync(int id, Book entity) {
            throw new NotImplementedException();
        }
    }
}
