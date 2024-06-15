namespace CodingAssessment.Models.Pagination;

public record Pagination(
    int CurrentPage, 
    int TotalPages, 
    int PageSize, 
    int TotalCount
);