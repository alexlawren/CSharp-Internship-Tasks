using Library.Application.Common;
using Library.Application.Interfaces;
using Library.Domain.Models;
using Library.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly LibraryContext _context;

        public AuthorRepository (LibraryContext context)
        {
            _context = context;
        }
        public async Task<PagedList<Author>> GetAllAsync(int pageNumber, int pageSize, int? bornAfter, int? bornBefore)
        {
            var query = _context.Authors.AsNoTracking();

            if (bornAfter.HasValue)
            {
                query = query.Where(a => a.DateOfBirth.Year > bornAfter.Value);
            }

            if (bornBefore.HasValue)
            {
                query = query.Where(a => a.DateOfBirth.Year < bornBefore.Value);
            }

            query = query.OrderBy(a => a.Name);

            return await PagedList<Author>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors
                .AsNoTracking()
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<Author?> AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task UpdateAsync(Author author)
        {
            await _context.Authors
                .Where(a => a.Id == author.Id)
                .ExecuteUpdateAsync(s => s
                    .SetProperty(a => a.Name, author.Name)
                    .SetProperty(a => a.DateOfBirth, author.DateOfBirth)
                    );
        }

        public async Task DeleteAsync(int id)
        {
            await _context.Authors
                .Where (a => a.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<PagedList<Author>> GetAllWithBookCountAsync(int pageNumber, int pageSize, int? minBooks, int? maxBooks)
        {
            var query = _context.Authors
                .Include(a => a.Books)
                .AsNoTracking();

            if(minBooks.HasValue)
            {
                query = query.Where(a => a.Books.Count >= minBooks.Value);
            }

            if(maxBooks.HasValue)
            {
                query = query.Where(a => a.Books.Count <= maxBooks.Value);
            }
            query = query.OrderBy(a => a.Name);
            return await PagedList<Author>.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<IEnumerable<Author>> FindAuthorsByNameAsync(string nameQuery)
        {
            return await _context.Authors
                .Where(author =>  author.Name.Contains(nameQuery))
                .AsNoTracking()
                .ToListAsync();
        }
    }
}
