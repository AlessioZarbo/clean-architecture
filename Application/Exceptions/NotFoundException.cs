namespace Application.Exceptions;

/// <summary>
/// Represents an exception that is thrown when a requested resource is not found.
/// </summary>
public class NotFoundException : Exception {

	/// <summary>
	/// Initializes a new instance of the <see cref="NotFoundException"/> class with a specified error message.
	/// </summary>
	/// <param name="entityName"></param>
	/// <param name="id"></param>
	public NotFoundException(Type entityName, int id) : base($"{entityName.Name} with id: {id} was not found") { }
}
