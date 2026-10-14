using Application.DTO.User;
using FluentValidation;

namespace Application.Validators.User;

/// <summary>
/// Validator class for validating the UserCreateDto object. This class inherits from AbstractValidator and defines validation rules for the properties of UserCreateDto.
/// </summary>
public class UserCreateDtoValidator : AbstractValidator<UserCreateDto> {

	/// <summary>
	/// Initializes a new instance of the UserCreateDtoValidator class and defines validation rules for the UserCreateDto properties.
	/// </summary>
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
