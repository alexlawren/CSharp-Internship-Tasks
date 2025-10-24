using Library.Application.Interfaces;
using Library.Domain.Models;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryContext _context;
        public BookRepository(LibraryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Book>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Books
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Book?> GetByIdAsync(int id)
        {
            return await _context.Books
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<Book?> AddAsync(Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task UpdateAsync(Book book)
        {
            await _context.Books
                .Where(b => b.Id == book.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(b => b.PublishedYear, book.PublishedYear)
                    .SetProperty(b => b.AuthorId, book.AuthorId)
                    .SetProperty(b => b.Title, book.Title)
                );
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Books
                .Where(b => b.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Book>> GetBooksPublishedAfterYearAsync(int year)
        {
            return await _context.Books
                .Where(b => b.PublishedYear > year)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task<bool> HasBooksAsync(int authorId)
        {
            return await _context.Books.AnyAsync(b => b.AuthorId == authorId);
        }
    }
}
