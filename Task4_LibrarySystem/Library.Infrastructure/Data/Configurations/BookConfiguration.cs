using Bogus;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Data.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        private static readonly List<Book> _books = GenerateBooks(100);
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.HasData(_books);
        }

        private static List<Book> GenerateBooks(int count)
        {
            var staticReferenceDate = new DateTime(2025, 1, 1);
            var bookFaker = new Faker<Book>("ru")
                .UseSeed(456)
                .RuleFor(b => b.Id, f => f.IndexFaker + 1)
                .RuleFor(b => b.Title, f => f.Lorem.Sentence(f.Random.Int(2, 5)))
                .RuleFor(b => b.PublishedYear, f => f.Date.Past(50, staticReferenceDate).Year)
                .RuleFor(b => b.AuthorId, f => f.Random.Int(1, 100));

            return bookFaker.Generate(count);
        }
    }
}   
