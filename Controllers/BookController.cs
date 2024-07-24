using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            this._bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBook(int id) 
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null) 
            { 
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        public async Task<ActionResult<Book>> AddBook(Book book) 
        {
            await _bookService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBook(int id, Book book) 
        {
            if (id != book.Id) 
            {
                return BadRequest();
            }

            await _bookService.UpdateBookAsync(book);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook(int id) 
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
