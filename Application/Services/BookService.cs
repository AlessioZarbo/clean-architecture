using Application.DTO.Book;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services {
    public class BookService : IBookService {
        public Task<BookCreateDto> CreateBookAsync(BookCreateDto bookDto) {
            throw new NotImplementedException();
        }

        public Task<BookDto> DeleteBookAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BookDto>> GetAllBooksAsync() {
            throw new NotImplementedException();
        }

        public Task<BookDto> GetBookByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<BookDto> UpdateBookAsync(int id, BookCreateDto bookDto) {
            throw new NotImplementedException();
        }
    }
}
