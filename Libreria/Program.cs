using API.Middlewares;
using Application;
using Application.Validators.User;
using Asp.Versioning;
using FluentValidation;
using Infrastructure;
using Scalar.AspNetCore;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Registra tutti i validatori presenti nell'assembly
builder.Services.AddValidatorsFromAssemblyContaining<UserCreateDtoValidator>();

// Attiva l'automazione MVC
builder.Services.AddFluentValidationAutoValidation();

// Configura il logging per l'applicazione
builder.Logging
    .ClearProviders()
    .AddSimpleConsole(options => {
        options.IncludeScopes = true;
        options.SingleLine = true;
        options.TimestampFormat = "[yyyy-MM-dd HH:mm:ss] ";
    });

// Aggiunta configurazione per ApiVersioning
builder.Services
    .AddProblemDetails()
    .AddApiVersioning(options =>
    {
        options.DefaultApiVersion = new ApiVersion(1, 0);
        options.AssumeDefaultVersionWhenUnspecified = true;
        options.ReportApiVersions = true;
        options.ApiVersionReader = ApiVersionReader.Combine(
            new QueryStringApiVersionReader("api-version"),
            new HeaderApiVersionReader("X-Version"),
            new MediaTypeApiVersionReader("ver")
        );
    })
    .AddApiExplorer(options =>
    {
        options.GroupNameFormat = "'v'VVV";
        options.SubstituteApiVersionInUrl = true;
    });

var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<RequestLoggingMiddleware>();
app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();
app.MapScalarApiReference();
app.Run();
