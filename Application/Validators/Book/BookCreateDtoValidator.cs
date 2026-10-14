using Application.DTO.Book;

namespace Application.Validators.Book;

using FluentValidation;

/// <summary>
/// Validator class for validating the BookCreateDto object. This class inherits from AbstractValidator and defines validation rules for the properties of BookCreateDto.
/// </summary>
public class BookCreateDtoValidator : AbstractValidator<BookCreateDto> {

	/// <summary>
	/// Initializes a new instance of the BookCreateDtoValidator class and defines validation rules for the BookCreateDto properties.
	/// </summary>
	public BookCreateDtoValidator() {

		RuleFor(book => book.Title)
			.NotNull()
			.NotEmpty()
			.WithMessage("Title is required");

		RuleFor(book => book.IsAvailable)
			.NotNull()
			.NotEmpty()
			.WithMessage("IsAvailable is required");
	}
}
