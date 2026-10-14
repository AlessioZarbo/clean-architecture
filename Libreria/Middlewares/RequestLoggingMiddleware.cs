using System.Diagnostics;

namespace API.Middlewares;

/// <summary>
/// Middleware for logging HTTP requests and responses, including correlation IDs and execution time.
/// </summary>
public class RequestLoggingMiddleware {

	/// <summary>
	/// The name of the header used to store the correlation ID for tracking requests.
	/// </summary>
	private const string CORRELATION_ID_HEADER = "X-Correlation-ID";

	/// <summary>
	/// The logger for logging request and response details.
	/// </summary>
	private readonly ILogger<RequestLoggingMiddleware> _logger;

	/// <summary>
	/// The next middleware in the pipeline.
	/// </summary>
	private readonly RequestDelegate _next;

	/// <summary>
	/// Initializes a new instance of the <see cref="RequestLoggingMiddleware"/> class.
	/// </summary>
	/// <param name="next"></param>
	/// <param name="logger"></param>
	public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger) {

		_next = next;
		_logger = logger;
	}

	/// <summary>
	/// Invokes the middleware to log HTTP requests and responses, including correlation IDs and execution time.
	/// </summary>
	/// <param name="context"></param>
	public async Task InvokeAsync(HttpContext context) {

		var stopwatch = Stopwatch.StartNew();

		var correlationId = (context.Request.Headers[CORRELATION_ID_HEADER]);
		if (string.IsNullOrEmpty(correlationId)) {

			correlationId = Guid.NewGuid().ToString();
			context.Request.Headers[CORRELATION_ID_HEADER] = correlationId;
		}

		context.Response.Headers[CORRELATION_ID_HEADER] = correlationId;

		var method = context.Request.Method;
		var route =  context.Request.Path;

		_logger.LogInformation($"Request starting {method} {route}");

		using (_logger.BeginScope(new Dictionary<string, object> { ["CorrelationId"] = correlationId }))
			await _next(context);

		stopwatch.Stop();

		_logger.LogInformation($"Request finished {method} {route} - {context.Response.StatusCode} - {context.Response.ContentType} - {stopwatch.ElapsedMilliseconds} ms");
	}
}
