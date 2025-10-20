using Library.Domain.Models;

namespace Library.Infrastructure.Data
{
    public static class MemoryStorage
    {
        public static readonly List<Author> Authors = new List<Author>
        {
            new Author { Id = 1, Name = "Джеффри Рихтер", DateOfBirth = new System.DateTime(1964, 7, 27) },
            new Author { Id = 2, Name = "Олифер Виктор", DateOfBirth = new System.DateTime(1944, 6, 11)}
        };

        public static readonly List<Book> Books = new List<Book>
        {
            new Book { Id = 1, Title = "CLR VIA C#", PublishedYear = 2012, AuthorId = 1 },
            new Book { Id = 2, Title = "Компьютерные сети", PublishedYear = 2021, AuthorId= 2 }
        };
    }
}
