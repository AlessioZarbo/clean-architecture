namespace Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when an invalid page number is provided for pagination.
/// </summary>
public class PaginationException : Exception {

	/// <summary>
	/// Initializes a new instance of the <see cref="PaginationException"/> class with a specified error message.
	/// </summary>
	/// <param name="page"></param>
	public PaginationException(int? page) : base($"Invalid page number: {page}") {
	}

	public PaginationException(int? page, int minPageSize, int maxPageSize) : base($"Invalid page number: {page}. Must be between {minPageSize} and {maxPageSize}.") {
	}
}
