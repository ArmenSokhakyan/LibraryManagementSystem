using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task AddUserAsync(User user)
        {
            await _repository.AddUserAsync(user);
        }

        public async Task DeleteUserAsync(int id)
        {
            await _repository.DeleteUserAsync(id);
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _repository.GetAllUsersAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _repository.GetUserByIdAsync(id);
        }

        public async Task<User> GetUserByUsernameAndPasswordAsync(string username, string password)
        {
            return await _repository.GetUserByUsernameAndPasswordAsync(username, password);
        }

        public async Task UpdateUserAsync(User user)
        {
            await _repository.UpdateUserAsync(user);
        }
    }
}
