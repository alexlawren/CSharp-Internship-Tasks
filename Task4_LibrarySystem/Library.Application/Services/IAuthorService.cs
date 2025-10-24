using Library.Application.DTOs;
using Library.Domain.Models;

namespace Library.Application.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync(int pageNumber, int pageSize);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author newAuthor);
        Task UpdateAuthorAsync(int id, Author newAuthor);   
        Task DeleteAuthorAsync(int id);
        Task<IEnumerable<Author>> GetAllAuthorsWithBookCountAsync(int pageNumber, int pageSize);
        Task<IEnumerable<AuthorDto>> FindAuthorsByNameAsync(string nameQuery);
    }
}
