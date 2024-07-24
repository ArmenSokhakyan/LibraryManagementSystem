using LibraryManagementSystem.Data;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagementSystem.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext libraryContext) 
        {
            _context = libraryContext;
        }

        public async Task AddBookAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null) 
            { 
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _context.Books.FindAsync(id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }
    }
}
