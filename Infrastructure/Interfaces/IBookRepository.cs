using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Interfaces {
    public interface IBookRepository : IRepository<Book> {

        /// <summary>
        /// Gets all books asynchronously with pagination.
        /// </summary>
        /// <returns></returns>
        Task <IEnumerable<Book>> GetAllPaginatedAsync(int page, int pageSize);

        /// <summary>
        /// Gets the total count of books asynchronously.
        /// </summary>
        /// <returns></returns>
        Task <int> TotalCountAsync();
    }
}
