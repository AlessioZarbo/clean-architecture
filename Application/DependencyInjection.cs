using Application.Interfaces;
using Application.Services;
using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application {

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
        public static IServiceCollection AddApplication(
            this IServiceCollection services) {

            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IReservationService, ReservationService>();
            services.AddScoped<IUserService, UserService>();

            return services;
        }
    }
}
