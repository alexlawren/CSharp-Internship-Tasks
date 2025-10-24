using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Services;
using Library.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetAllBooks(
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 10)
        {
            var books = await _bookService.GetAllBooksAsync(pageNumber, pageSize);

            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
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

            var bookDto = _mapper.Map<BookDto>(book);
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<ActionResult<BookDto>> CreateBook([FromBody] CreateBookDto bookDto)
        {
            var bookModel = _mapper.Map<Book>(bookDto);
            var createdBook = await _bookService.CreateBookAsync(bookModel);
            var bookToReturn = _mapper.Map<BookDto>(createdBook);
            return CreatedAtAction(nameof(GetBookById), new { id = bookToReturn.Id }, bookToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateBook(int id, [FromBody] UpdateBookDto bookDto)
        {
            var bookModel = _mapper.Map<Book>(bookDto);
            bookModel.Id = id;
            await _bookService.UpdateBookAsync(id, bookModel);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBookAsync(id);
            return NoContent();
        }

        [HttpGet("published-after/{year}")]
        public async Task<ActionResult<IEnumerable<BookDto>>> GetBooksPublishedAfter(int year)
        {
            if (year < 0 || year > DateTime.UtcNow.Year)
            {
                return BadRequest($"Год должен быть в диапазоне от 0 до {DateTime.UtcNow.Year}.");
            }

            var books = await _bookService.GetBooksPublishedAfterAsync(year);
            var booksDto = _mapper.Map<IEnumerable<BookDto>>(books);
            return Ok(booksDto);
        }
    }
}
