using Application.DTO.Author;
using FluentValidation;

namespace Application.Validators.Author;

public class AuthorCreateDtoValidator :  AbstractValidator<AuthorCreateDto>{

	public AuthorCreateDtoValidator() {

		RuleFor(author => author.Id)
			.GreaterThan(0)
			.NotNull()
			.WithMessage("Author Id cannot be null or empty");

		RuleFor(author => author.Name)
			.NotEmpty()
			.NotNull()
			.WithMessage("Author name cannot be null or empty");

		RuleFor(author => author.Surname)
			.NotEmpty()
			.NotNull()
			.WithMessage("Author surname cannot be null or empty");
	}
}
