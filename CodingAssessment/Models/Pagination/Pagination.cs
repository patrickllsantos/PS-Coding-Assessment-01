namespace CodingAssessment.Models.Pagination;

/// <summary>
/// Represents pagination details.
/// </summary>
/// <param name="CurrentPage">The current page number.</param>
/// <param name="TotalPages">The total number of pages.</param>
/// <param name="PageSize">The number of items per page.</param>
/// <param name="TotalCount">The total number of items.</param>
public record Pagination(
    int CurrentPage, 
    int TotalPages, 
    int PageSize, 
    int TotalCount
);