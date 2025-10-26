using Library.Application.Common;
using Library.Domain.Models;

namespace Library.Application.Interfaces
{
    public interface IAuthorRepository
    {
        Task<PagedList<Author>> GetAllAsync(int pageNumber, int pageSize, int? bornAfter, int? bornBefore);
        Task<Author?> GetByIdAsync(int id);
        Task<Author?> AddAsync(Author author);
        Task UpdateAsync(Author author);
        Task DeleteAsync(int id);
        Task<PagedList<Author>> GetAllWithBookCountAsync(int pageNumber, int pageSize, int? minBooks, int? maxBooks);
        Task<IEnumerable<Author>> FindAuthorsByNameAsync(string nameQuery);
    }
}
