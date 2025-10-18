using Library.API.DTOs;
using Library.API.Models;
using Library.API.Repositories;
using Library.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Reflection;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks()
        {
            var books = await _bookService.GetAllBooksAsync();
            var booksDto = books.Select(b => new BookDto { Id = b.Id, Title = b.Title, PublishedYear = b.PublishedYear, AuthorId = b.AuthorId });
            return Ok(booksDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookDto>> GetBookById(int id)
        {
            var book = await _bookService.GetBookByIdAsync(id);

            if (book == null)
            {
                return NotFound($"Книга с ID = {id} не найдена.");
            }

            var bookDto = new BookDto { Id = book.Id, Title = book.Title, PublishedYear = book.PublishedYear, AuthorId = book.AuthorId };
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<ActionResult<Book?>> CreateBook([FromBody] CreateBookDto bookDto)
        {
            var bookModel = new Book
            {
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                AuthorId = bookDto.AuthorId,
            };

            var createdBook = await _bookService.CreateBookAsync(bookModel);
            var bookToReturn = new BookDto { Id = createdBook.Id, Title = createdBook.Title, PublishedYear = createdBook.PublishedYear, AuthorId = createdBook.AuthorId };
            return CreatedAtAction(nameof(GetBookById), new { id = bookToReturn.Id }, bookToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] UpdateBookDto bookDto)
        {
            var bookModel = new Book
            {
                Id = id,
                Title = bookDto.Title,
                PublishedYear = bookDto.PublishedYear,
                AuthorId = bookDto.AuthorId,
            };

            await _bookService.UpdateBookAsync(id, bookModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }
    }
}
