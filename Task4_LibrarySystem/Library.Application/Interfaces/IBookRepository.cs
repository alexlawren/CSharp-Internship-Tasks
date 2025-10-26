using Library.Application.Common;
using Library.Domain.Models;

namespace Library.Application.Interfaces
{
    public interface IBookRepository
    {
        Task<PagedList<Book>> GetAllAsync(int pageNumber, int pageSize);
        Task<Book?> GetByIdAsync(int id);
        Task<Book?> AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task DeleteAsync(int id);
        Task<IEnumerable<Book>> GetBooksPublishedAfterYearAsync(int year);
        Task<bool> HasBooksAsync(int authorId);
    }
}
