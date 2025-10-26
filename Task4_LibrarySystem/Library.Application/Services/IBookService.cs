using Library.Application.Common;
using Library.Application.DTOs;
using Library.Domain.Models;

namespace Library.Application.Services
{
    public interface IBookService
    {
        Task<PagedList<Book>> GetAllBooksAsync(int pageNumber, int pageSize, int? publishedYear);
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book newBook);
        Task UpdateBookAsync(int id, Book updatedBook);
        Task DeleteBookAsync(int id);
        Task<IEnumerable<BookDto>> GetBooksPublishedAfterAsync(int year);
        Task<bool> HasBooksAsync(int authorId);
    }
}
