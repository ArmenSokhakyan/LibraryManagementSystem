using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Interfaces
{
    public interface IRentalService
    {
        Task<Rental> GetRentalByIdAsync(int id);
        Task<IEnumerable<Rental>> GetAllRentalsAsync();
        Task AddRentalAsync(Rental rental);
        Task UpdateRentalAsync(Rental rental);
        Task DeleteRentalAsync(int id);
    }
}
