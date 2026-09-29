using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces {

    /// <summary>
    /// Represents a unit of work that encapsulates a set of operations to be performed as a single transaction.
    /// </summary>
    public interface IUnitOfWork {

        /// <summary>
        /// Saves the changes made within the unit of work asynchronously.
        /// </summary>
        /// <returns>The task representing the asynchronous operation.</returns>
        Task SaveChangesAsync();
    }
}
