using Library.Application.Interfaces;
using Library.Domain.Models;

namespace Library.Application.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookService _bookService;

        public AuthorService(IAuthorRepository authorRepository, IBookService bookService)
        {
            _authorRepository = authorRepository;
            _bookService = bookService;
        }

        public async Task<IEnumerable<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }

        public async Task<Author> CreateAuthorAsync(Author newAuthor)
        {
            return await _authorRepository.AddAsync(newAuthor);
        }

        public async Task UpdateAuthorAsync(int id, Author newAuthor)
        {
            var exestingAuthor = await _authorRepository.GetByIdAsync(id);
            if (exestingAuthor == null)
            {
                throw new KeyNotFoundException($"Автор с ID = {id} не найден для обновления.");
            }
            await _authorRepository.UpdateAsync(newAuthor);
        }

        public async Task DeleteAuthorAsync(int id)
        {
            var author = await _authorRepository.GetByIdAsync(id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Автор с ID = {id} не найден.");
            }

            var books = await _bookService.GetAllBooksAsync();
            if(books.Any(b => b.AuthorId == id))
            {
                throw new InvalidOperationException($"Нельзя удалить автора с ID = {id}, так как у него есть книги.");
            }
            await _authorRepository.DeleteAsync(id);
        }
    }
}
