using Library.Domain.Models;

namespace Library.Application.Services
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAllAuthorsAsync();
        Task<Author> GetAuthorByIdAsync(int id);
        Task<Author> CreateAuthorAsync(Author newAuthor);
        Task UpdateAuthorAsync(int id, Author newAuthor);   
        Task DeleteAuthorAsync(int id);
    }
}
