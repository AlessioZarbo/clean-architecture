using Infrastructure.Interfaces;
using Infrastructure.Perstistence;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure {

    /// <summary>
    /// This static class provides extension methods for configuring application services and dependencies.
    /// </summary>
    public static class DependencyInjection {

        /// <summary>
        /// Adds application services and dependencies to the specified IServiceCollection.
        /// </summary>
        /// <param name="services">The IServiceCollection to which the services will be added.</param>
        /// <param name="configuration">The configuration to use for the application.</param>
        /// <returns>The same IServiceCollection instance.</returns>
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration) {

            services.AddSqlServer<LibraryDbContext>(
                configuration.GetConnectionString("DefaultConnection"));

            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IReservationRepository, ReservationRepository>();
            services.AddScoped<IUserRepository, UserRepository>();

            return services;
        }
    }
}
