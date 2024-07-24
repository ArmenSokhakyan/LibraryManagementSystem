using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByIdAsync(int id);
        Task<User> GetUserByUsernameAndPasswordAsync(string username, string password);
        Task<IEnumerable<User>> GetAllUsersAsync();
        Task AddUserAsync(User user);
        Task UpdateUserAsync(User user);
        Task DeleteUserAsync(int id);

    }
}
