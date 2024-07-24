using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IAuthService
    {
        Task<string> Authenticate(string username, string password);
        Task Register(UserRegisterModel model);
    }
}
