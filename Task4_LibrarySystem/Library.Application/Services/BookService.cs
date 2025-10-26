using Library.Application.Common;
using Library.Application.DTOs;
using Library.Application.Interfaces;
using Library.Domain.Models;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IAuthorRepository _authorRepository;

        public BookService(IBookRepository bookRepository, IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }

        public async Task<Book> CreateBookAsync (Book newBook)
        {
            var authorExist = await _authorRepository.GetByIdAsync(newBook.AuthorId);
            if (authorExist == null)
            {
                throw new InvalidOperationException($"Невозможно создать книгу для несуществующего автора с ID = {newBook.AuthorId}.");
            }

            return await _bookRepository.AddAsync(newBook);
        }

        public async Task DeleteBookAsync(int id)
        {
            var book = await _bookRepository.GetByIdAsync(id);
            if(book == null)
            {
                throw new KeyNotFoundException($"Книга с ID = {id} не найдена.");
            }

            await _bookRepository.DeleteAsync(id);
        }

        public async Task<PagedList<Book>> GetAllBooksAsync(int pageNumber, int pageSize, int? publishedYear)
        {
            return await _bookRepository.GetAllAsync(pageNumber, pageSize, publishedYear);
        }


        public async Task<Book?> GetBookByIdAsync(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }

        public async Task UpdateBookAsync(int id, Book updatedBook)
        {
            var existingBook = await _bookRepository.GetByIdAsync(id);
            if (existingBook == null)
            {
                throw new KeyNotFoundException($"Книга с ID = {id} не найдена для обновления.");
            }

            var authorExists = await _authorRepository.GetByIdAsync(updatedBook.AuthorId);
            if (authorExists == null)
            {
                throw new InvalidOperationException($"Невозможно обновить книгу: автор с ID = {updatedBook.AuthorId} не найден.");
            }

            await _bookRepository.UpdateAsync(updatedBook);
        }

        public async Task<IEnumerable<BookDto>> GetBooksPublishedAfterAsync(int year)
        {
            var books = await _bookRepository.GetBooksPublishedAfterYearAsync(year);
            return books.Select(b => new BookDto
            {
                Id = b.Id,
                AuthorId = b.AuthorId,
                Title = b.Title,
                PublishedYear = b.PublishedYear,
            });
        }

        public async Task<bool> HasBooksAsync(int authorId)
        {
            return await _bookRepository.HasBooksAsync(authorId);
        }
    }
}
