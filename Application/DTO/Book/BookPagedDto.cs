namespace Application.DTO.Book;

/// <summary>
/// Represents a paginated list of books along with pagination metadata.
/// </summary>
public class BookPagedDto {

    /// <summary>
    /// Gets or sets the collection of books in the current page.
    /// </summary>
    public IEnumerable<BookDto>? Books { get; set; }

    /// <summary>
    /// Gets or sets the total number of books available across all pages.
    /// </summary>
    public int TotalCount { get; set; }

    /// <summary>
    /// Gets or sets the current page number in the pagination.
    /// </summary>
    public int CurrentPage { get; set; }

    /// <summary>
    /// Gets or sets the number of books displayed per page in the pagination.
    /// </summary>
    public int PageSize { get; set; }
}
