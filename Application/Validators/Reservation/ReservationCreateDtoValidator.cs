using Application.DTO.Reservation;
using FluentValidation;

namespace Application.Validators.Reservation;

public class ReservationCreateDtoValidator : AbstractValidator<ReservationCreateDto> {
	public ReservationCreateDtoValidator() {

		RuleFor(reservation => reservation.Books)
			.NotEmpty()
			.WithMessage("Books list cannot be empty")
			.Must(books => books != null && books.Count > 0)
			.WithMessage("Books list must contain at least one book");

		RuleFor(reservation => reservation.User)
			.NotNull()
			.WithMessage("User cannot be null");

		RuleFor(reservation => reservation.DaysToReserve)
			.GreaterThan(0)
			.WithMessage("Days to reserve must be greater than zero");
	}

}
