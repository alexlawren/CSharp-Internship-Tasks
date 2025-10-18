using FluentValidation;
using Library.API.DTOs;

namespace Library.API.Validators
{
    public class UpdateBookDtoValidator : AbstractValidator<UpdateBookDto>
    {
        public UpdateBookDtoValidator()
        {
            RuleFor(book => book.Title)
                .NotEmpty().WithMessage("Название книги не может быть пустым")
                .MaximumLength(200).WithMessage("Название книги не должно превышать 200 символов");

            RuleFor(book => book.PublishedYear)
                .InclusiveBetween(1, DateTime.Now.Year)
                .WithMessage($"Год публикации должен быть между 1 и {DateTime.Now.Year}");

            RuleFor(book => book.AuthorId)
                .NotEmpty().WithMessage("Необходимо указать ID автора");
        }
    }
}
