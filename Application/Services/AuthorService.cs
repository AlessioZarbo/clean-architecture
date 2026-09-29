using Application.DTO.Author;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services {
    public class AuthorService : IAuthorService {
        public Task<AuthorCreateDto> CreateAuthorAsync(AuthorCreateDto authorDto) {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> DeleteAuthorAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorDto>> GetAllAuthorsAsync() {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> GetAuthorByIdAsync(int id) {
            throw new NotImplementedException();
        }

        public Task<AuthorDto> UpdateAuthorAsync(int id, AuthorCreateDto authorDto) {
            throw new NotImplementedException();
        }
    }
}
