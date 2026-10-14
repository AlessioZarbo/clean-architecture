using API.Middlewares;
using Application;
using Application.Validators.User;
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

var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.MapControllers();
app.MapScalarApiReference();
app.Run();
