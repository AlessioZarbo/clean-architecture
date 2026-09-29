using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure {

    /// <summary>
    /// Represents the database context for the library application, providing access to the Books and Authors tables.
    /// </summary>
    public class LibraryDbContext : DbContext {

        /// <summary>
        /// Initializes a new instance of the LibraryDbContext class with the specified options.
        /// </summary>
        /// <param name="options"></param>
        public LibraryDbContext(DbContextOptions<LibraryDbContext> options) : base(options) { }

        /// <summary>
        /// Initializes a new instance of the LibraryDbContext class with default options.
        /// </summary>
        public LibraryDbContext() { }

        /// <summary>
        /// Gets or sets the DbSet representing the Books table in the database.
        /// </summary>
        public DbSet<Book> Books { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the Authors table in the database.
        /// </summary>
        public DbSet<Author> Authors { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the Reservations table in the database.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Gets or sets the DbSet representing the Reservations table in the database.
        /// </summary>
        public DbSet<Reservation> Reservations { get; set; }
    }
}
