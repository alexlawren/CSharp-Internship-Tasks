using Library.Application.Interfaces;
using Library.Domain.Models;
using Library.Infrastructure.Data;

namespace Library.Infrastructure.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public Task<IEnumerable<Author>> GetAllAsync()
        {
            return Task.FromResult<IEnumerable<Author>>(MemoryStorage.Authors.ToList());
        }

        public Task<Author?> GetByIdAsync(int id)
        {
            var author = MemoryStorage.Authors.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(author);
        }

        public Task<Author?> AddAsync(Author author)
        {
            var MaxId = MemoryStorage.Authors.Any() ? MemoryStorage.Authors.Max(b => b.Id) : 0;
            author.Id = MaxId + 1;
            MemoryStorage.Authors.Add(author);
            return Task.FromResult(author);
        }

        public Task UpdateAsync(Author author)
        {
            var existingAuthor = MemoryStorage.Authors.FirstOrDefault(b => b.Id == author.Id);
            if (existingAuthor != null)
            {
                existingAuthor.Name = author.Name;
                existingAuthor.DateOfBirth = author.DateOfBirth;
            }
            return Task.CompletedTask;
        }

        public Task DeleteAsync(int id)
        {
            var authorToRemove = MemoryStorage.Authors.FirstOrDefault(b => b.Id == id);
            if (authorToRemove != null)
            {
                MemoryStorage.Authors.Remove(authorToRemove);
            }
            return Task.CompletedTask;
        }
    }
}
