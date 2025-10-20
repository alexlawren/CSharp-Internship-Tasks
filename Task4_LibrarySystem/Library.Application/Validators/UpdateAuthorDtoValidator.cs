using FluentValidation;
using Library.Application.DTOs;

namespace Library.Application.Validators
{
    public class UpdateAuthorDtoValidator : AbstractValidator<UpdateAuthorDto>
    {
        public UpdateAuthorDtoValidator()
        {
            RuleFor(author => author.Name)
                .NotEmpty()
                .WithMessage("Имя автора не может быть пустым")

                .Length(2, 100)
                .WithMessage("Имя автора должно содержать от 2 до 100 символов");

            RuleFor(author => author.DateOfBirth)
                .NotEmpty()
                .WithMessage("Дата рождения обязательна");
        }
    }
}
