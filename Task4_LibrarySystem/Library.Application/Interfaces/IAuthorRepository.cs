using Library.Domain.Models;

namespace Library.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<IEnumerable<Author>> GetAllAsync(int pageNumber, int pageSize);
        Task<Author?> GetByIdAsync(int id);
        Task<Author?> AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
        Task<IEnumerable<Author>> GetAllWithBookCountAsync(int pageNumber, int pageSize);
        Task<IEnumerable<Author>> FindAuthorsByNameAsync(string nameQuery);
    }
}
