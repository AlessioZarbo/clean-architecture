using Application.DTO.User;
using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Services {
    public class UserService : IUserService {
        public Task<UserDto> CreateUserAsync(UserCreateDto userCreateDto) {
            throw new NotImplementedException();
        }

        public Task<UserDto> DeleteUserAsync(int userId) {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<UserDto>> GetAllUsersAsync() {
            throw new NotImplementedException();
        }

        public Task<UserDto> GetUserByIdAsync(int userId) {
            throw new NotImplementedException();
        }

        public Task<UserDto> UpdateUserAsync(int id, UserCreateDto userCreateDto) {
            throw new NotImplementedException();
        }
    }
}
