using FluentValidation;
using Library.API.DTOs;

namespace Library.API.Validators
{
    public class CreateAuthorDtoValidator : AbstractValidator<CreateAuthorDto>
    {
        public CreateAuthorDtoValidator()
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
