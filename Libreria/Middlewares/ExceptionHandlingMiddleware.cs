using System.Text.Json;
using Application.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace API.Middlewares;

/// <summary>
/// Middleware for handling exceptions in the application.
/// </summary>
public class ExceptionHandlingMiddleware {

	/// <summary>
	/// The next middleware in the pipeline.
	/// </summary>
	private readonly RequestDelegate _next;

	/// <summary>
	/// The logger for logging exception details.
	/// </summary>
	private readonly ILogger<ExceptionHandlingMiddleware> _logger;

	/// <summary>
	/// Initializes a new instance of the <see cref="ExceptionHandlingMiddleware"/> class.
	/// </summary>
	/// <param name="next"></param>
	/// <param name="logger"></param>
	public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger) {

		_next = next;
		_logger = logger;
	}

	/// <summary>
	/// Invokes the middleware to handle exceptions during the request processing.
	/// </summary>
	/// <param name="context"></param>
	public async Task InvokeAsync(HttpContext context) {

		try {

			await _next(context);
		}
		catch (NotImplementedException e) {
			await WriteProblemDetailsAsync(
				context,
				StatusCodes.Status501NotImplemented,
				"Endpoint not implemented",
				e.Message);
		}
		catch (NotFoundException ex) {
			await WriteProblemDetailsAsync(
				context,
				StatusCodes.Status404NotFound,
				"Resource not found",
				ex.Message);
		}
		catch (PaginationException ex) {
			await WriteProblemDetailsAsync(
				context,
				StatusCodes.Status503ServiceUnavailable,
				"Pagination error",
				ex.Message);
		}
		catch (Exception e) {
			await WriteProblemDetailsAsync(
				context,
				StatusCodes.Status500InternalServerError,
				"An unexpected error occurred",
				e.Message);
		}
	}

	/// <summary>
	/// Writes problem details to the response.
	/// </summary>
	/// <param name="context"></param>
	/// <param name="statusCode"></param>
	/// <param name="title"></param>
	/// <param name="detail"></param>
	/// <returns></returns>
	public async Task WriteProblemDetailsAsync(
		HttpContext context,
		int statusCode,
		string title,
		string detail = null) {

		context.Response.StatusCode = statusCode;
		context.Response.ContentType = "application/problem+json";

		var problemDetails = new ProblemDetails {
			Status = statusCode,
			Title = title,
			Detail = detail
		};

		string json = JsonSerializer.Serialize(problemDetails);
		await context.Response.WriteAsync(json);
	}
}
