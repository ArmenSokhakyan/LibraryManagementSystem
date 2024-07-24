using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;

namespace LibraryManagementSystem.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository)
        {
            _repository = repository;
        }

        public async Task AddBookAsync(Book book)
        {
            await _repository.AddBookAsync(book);
        }

        public async Task DeleteBookAsync(int id)
        {
            await _repository.DeleteBookAsync(id);
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _repository.GetAllBooksAsync();
        }

        public async Task<Book> GetBookByIdAsync(int id)
        {
            return await _repository.GetBookByIdAsync(id);
        }

        public async Task UpdateBookAsync(Book book)
        {
            await _repository.UpdateBookAsync(book);
        }
    }
}
