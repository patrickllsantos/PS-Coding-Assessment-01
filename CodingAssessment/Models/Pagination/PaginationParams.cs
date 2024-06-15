using Microsoft.AspNetCore.Mvc;

namespace CodingAssessment.Models.Pagination;

/// <summary>
/// Contains parameters for pagination.
/// </summary>
public class PaginationParams
{
    /// <summary>Refers to the maximum amount of items per page allowed.</summary>
    private const int MaxPageSize = 50;

    /// <summary>Refers to the page number.</summary>
    [FromQuery(Name = "page")]
    public int PageNumber { get; set; } = 1;

    /// <summary>Refers to the amount of items per page.</summary>
    private int _pageSize = 10;

    /// <summary>
    /// Gets or sets the page size. If the set value exceeds the maximum page size, it will be set to the maximum value.
    /// </summary>
    [FromQuery(Name = "size")]
    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
    }
}
