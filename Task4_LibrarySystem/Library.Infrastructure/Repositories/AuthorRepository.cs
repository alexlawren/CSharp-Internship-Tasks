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
        public async Task<IEnumerable<Author>> GetAllAsync(int pageNumber, int pageSize)
        {
            return await _context.Authors
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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

        public async Task<IEnumerable<Author>> GetAllWithBookCountAsync(int pageNumber, int pageSize)
        {
            return await _context.Authors
                .Include(a => a.Books)
                .AsNoTracking()
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
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
