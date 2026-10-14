using Application.DTO.Book;

namespace Application.Validators.Book;

using FluentValidation;

public class BookCreateDtoValidator : AbstractValidator<BookCreateDto> {

	public BookCreateDtoValidator() {

		RuleFor(book => book.Title)
			.NotNull()
			.NotEmpty()
			.WithMessage("Title is required");

		RuleFor(book => book.IsAvailable)
			.NotEmpty()
			.WithMessage("IsAvailable is required");
	}
}
