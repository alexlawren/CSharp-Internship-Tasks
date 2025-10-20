using Library.Domain.Models;

namespace Library.Application.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book?> GetBookByIdAsync(int id);
        Task<Book> CreateBookAsync(Book newBook);
        Task UpdateBookAsync(int id, Book updatedBook);
        Task DeleteBookAsync(int id);
    }
}
