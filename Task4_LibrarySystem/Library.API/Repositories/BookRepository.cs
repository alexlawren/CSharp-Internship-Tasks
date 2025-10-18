using Library.API.Data;
using Library.API.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.API.Repositories
{
    public class BookRepository : IBookRepository
    {
        public Task<IEnumerable<Book>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Book>>(MemoryStorage.Books.ToList());
        }

        public Task<Book?> GetByIdAsync(int id)
        {
            var book = MemoryStorage.Books.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(book);
        }

        public Task<Book?> AddAsync(Book book)
        {
            var MaxId = MemoryStorage.Books.Any() ? MemoryStorage.Books.Max(b => b.Id) : 0;
            book.Id = MaxId + 1;
            MemoryStorage.Books.Add(book);
            return Task.FromResult(book);
        }

        public Task UpdateAsync(Book book)
        {
            var existingBook = MemoryStorage.Books.FirstOrDefault(b => b.Id == book.Id);
            if (existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.PublishedYear = book.PublishedYear;
                existingBook.AuthorId = book.AuthorId;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var bookToRemove = MemoryStorage.Books.FirstOrDefault(b => b.Id == id); 
            if (bookToRemove != null)
            {
                MemoryStorage.Books.Remove(bookToRemove);
            }
            return Task.CompletedTask;
        }
    }
}
