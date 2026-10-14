using Application.DTO.Author;
using FluentValidation;

namespace Application.Validators.Author;

/// <summary>
/// Validator class for validating the AuthorCreateDto object. This class inherits from AbstractValidator and defines validation rules for the properties of AuthorCreateDto.
/// </summary>
public class AuthorCreateDtoValidator :  AbstractValidator<AuthorCreateDto>{

	/// <summary>
	/// Initializes a new instance of the AuthorCreateDtoValidator class and defines validation rules for the AuthorCreateDto properties.
	/// </summary>
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
