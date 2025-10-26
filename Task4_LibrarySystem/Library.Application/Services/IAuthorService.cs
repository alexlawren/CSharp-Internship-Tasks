using Library.Application.Common;
using Library.Application.DTOs;
using Library.Domain.Models;

namespace Library.Application.Services
{
    public interface IAuthorService
    {
        Task<PagedList<Author>> GetAllAuthorsAsync(int pageNumber, int pageSize, int? bornAfter, int? bornBefore);
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author newAuthor);
        Task UpdateAuthorAsync(int id, Author newAuthor);   
        Task DeleteAuthorAsync(int id);
        Task<PagedList<Author>> GetAllAuthorsWithBookCountAsync(int pageNumber, int pageSize, int? minBooks, int? maxBooks);
        Task<IEnumerable<AuthorDto>> FindAuthorsByNameAsync(string nameQuery);
    }
}
