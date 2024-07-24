using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly LibraryContext _context;

        public RentalRepository(LibraryContext context)
        {
            _context = context;
        }

        public async Task AddRentalAsync(Rental rental)
        {
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRentalAsync(int id)
        {
            var rental = await _context.Rentals.FindAsync(id);
            if (rental != null) 
            {
                _context.Rentals.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Rental>> GetAllRentalsAsync()
        {
            return await _context.Rentals.ToListAsync();
        }

        public async Task<Rental> GetRentalByIdAsync(int id)
        {
            return await _context.Rentals.FindAsync(id);
        }

        public async Task UpdateRentalAsync(Rental rental)
        {
            _context.Rentals.Update(rental);
            _context.SaveChanges();
        }
    }
}
