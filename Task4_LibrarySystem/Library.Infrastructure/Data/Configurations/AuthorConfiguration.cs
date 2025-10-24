using Bogus;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.Infrastructure.Data.Configurations
{
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        private static readonly List<Author> _authors = GenerateAuthors(100);
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");

            builder.HasKey(a => a.Id);

            builder.Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(a => a.DateOfBirth)
            .IsRequired();

            builder.HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId);

            builder.HasData(_authors);
        }

        private static List<Author> GenerateAuthors(int count)
        {
            var staticReferenceDate = new DateTime(2025, 1, 1);

            var authorFaker = new Faker<Author>("ru")
                .UseSeed(123)
                .RuleFor(a => a.Id, f => f.IndexFaker + 1)
                .RuleFor(a => a.Name, f => f.Name.FullName())
                .RuleFor(a => a.DateOfBirth, f => f.Date.Past(80, staticReferenceDate.AddYears(-18)));

            return authorFaker.Generate(count);
        }
    }
}
