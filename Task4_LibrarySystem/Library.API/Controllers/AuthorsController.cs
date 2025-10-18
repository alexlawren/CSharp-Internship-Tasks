using Library.API.DTOs;
using Library.API.Models;
using Library.API.Repositories;
using Library.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorsController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AuthorDto>>> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthorsAsync();
            var authorsDto = authors.Select(a => new AuthorDto { Id = a.Id, Name = a.Name, DateOfBirth = a.DateOfBirth});
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

            var authorDto = new AuthorDto { Id = author.Id, Name = author.Name, DateOfBirth = author.DateOfBirth };
            return Ok(author);
        }

        [HttpPost]
        public async Task<ActionResult<AuthorDto>> CreateAuthor([FromBody] CreateAuthorDto authorDto)
        {
            var authorModel = new Author
            {
                Name = authorDto.Name,
                DateOfBirth = authorDto.DateOfBirth.Value
            };

            var createdAuthor = await _authorService.CreateAuthorAsync(authorModel);

            var authorToReturn = new AuthorDto { Id = createdAuthor.Id, Name = createdAuthor.Name, DateOfBirth = createdAuthor.DateOfBirth };

            return CreatedAtAction("GetAuthorById", new { id = authorToReturn.Id }, authorToReturn);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAuthor(int id, [FromBody] UpdateAuthorDto authorDto)
        {
            var authorModel = new Author
            {
                Id = id,
                Name = authorDto.Name,
                DateOfBirth = authorDto.DateOfBirth.Value
            };


            await _authorService.UpdateAuthorAsync(id, authorModel);
            return NoContent();

        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteAuthor(int id)
        {
            await _authorService.DeleteAuthorAsync(id);
            return NoContent();
        }
    }
}
