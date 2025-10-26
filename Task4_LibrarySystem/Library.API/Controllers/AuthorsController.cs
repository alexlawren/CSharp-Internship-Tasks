using AutoMapper;
using Library.Application.DTOs;
using Library.Application.Services;
using Library.Domain.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
        {
            var pagedAuthors = await _authorService.GetAllAuthorsAsync(pageNumber, pageSize);
            var paginationMetadata = new
            {
                pagedAuthors.TotalCount,
                pagedAuthors.PageSize,
                pagedAuthors.CurrentPage,
                pagedAuthors.TotalPages,
                pagedAuthors.HasPrevious,
                pagedAuthors.HasNext
            };

            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(paginationMetadata);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(pagedAuthors);
            return Ok(authorsDto);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDto>> GetAuthorById(int id)
        {
            var author = await _authorService.GetAuthorByIdAsync(id);

            if (author == null)
            {
                return NotFound($"Автор с ID = {id} не найден.");
            }

            var authorDto = _mapper.Map<AuthorDto>(author);
            return Ok(authorDto);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] CreateAuthorDto authorDto)
        {
            var authorModel = _mapper.Map<Author>(authorDto);

            var createdAuthor = await _authorService.CreateAuthorAsync(authorModel);

            var authorToReturn = _mapper.Map<AuthorDto>(createdAuthor); 

            return CreatedAtAction("GetAuthorById", new { id = authorToReturn.Id }, authorToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto authorDto)
        {
            var authorModel = _mapper.Map<Author>(authorDto);

            authorModel.Id = id;

            await _authorService.UpdateAuthorAsync(id, authorModel);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }

        [HttpGet("with-book-count")]
        public async Task<ActionResult<IEnumerable<AuthorWithBooksDto>>> GetAuthorsWithBookCount(
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagedAuthors = await _authorService.GetAllAuthorsWithBookCountAsync(pageNumber, pageSize);

            var paginationMetadata = new
            {
                pagedAuthors.TotalCount,
                pagedAuthors.PageSize,
                pagedAuthors.CurrentPage,
                pagedAuthors.TotalPages,
                pagedAuthors.HasPrevious,
                pagedAuthors.HasNext
            };
            Response.Headers["X-Pagination"] = JsonSerializer.Serialize(paginationMetadata);

            var authorsDto = _mapper.Map<IEnumerable<AuthorWithBooksDto>>(pagedAuthors);
            return Ok(authorsDto);
        }

        [HttpGet("search/{nameQuery}")]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> FindAuthorByName(string nameQuery)
        {
            if (string.IsNullOrWhiteSpace(nameQuery))
            {
                return BadRequest("Поисковый запрос не может быть пустым.");
            }
            var authors = await _authorService.FindAuthorsByNameAsync(nameQuery);
            var authorsDto = _mapper.Map<IEnumerable<AuthorDto>>(authors);
            return Ok(authorsDto);
        }
    }
}
