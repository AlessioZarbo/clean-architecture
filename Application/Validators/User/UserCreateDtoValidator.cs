using Application.DTO.User;
using FluentValidation;

namespace Application.Validators.User;

public class UserCreateDtoValidator : AbstractValidator<UserCreateDto> {

	public UserCreateDtoValidator() {

		RuleFor(user => user.Username)
			.NotEmpty()
			.NotNull()
			.WithMessage("Username is required");

		RuleFor(user => user.Email)
			.EmailAddress()
			.NotEmpty()
			.NotNull()
			.WithMessage("Email is required");

		RuleFor(user => user.Password)
			.NotEmpty()
			.NotNull()
			.WithMessage("Password is required");
	}
}
