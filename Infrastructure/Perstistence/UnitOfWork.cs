using Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Perstistence {

    /// <summary>
    /// Represents a unit of work that encapsulates a set of operations to be performed as a single transaction.
    /// </summary>
    public class UnitOfWork(LibraryDbContext ctx) : IUnitOfWork {

        /// <summary>
        /// The database context used for performing operations within the unit of work.
        /// </summary>
        private readonly LibraryDbContext _ctx = ctx;

        /// <summary>
        /// Saves the changes made within the unit of work asynchronously.
        /// </summary>
        /// <returns>The task representing the asynchronous operation.</returns>
        public Task SaveChangesAsync() {

            return _ctx.SaveChangesAsync();
        }
    }
}
