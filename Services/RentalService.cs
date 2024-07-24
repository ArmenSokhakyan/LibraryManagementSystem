using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _repository;

        public RentalService(IRentalRepository repository)
        {
            _repository = repository;
        }

        public async Task AddRentalAsync(Rental rental)
        {
            await _repository.AddRentalAsync(rental);
        }

        public async Task DeleteRentalAsync(int id)
        {
            await _repository.DeleteRentalAsync(id);
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _repository.GetAllRentalsAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            return await _repository.GetRentalByIdAsync(id);
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            await _repository.UpdateRentalAsync(rental);
        }
    }
}
