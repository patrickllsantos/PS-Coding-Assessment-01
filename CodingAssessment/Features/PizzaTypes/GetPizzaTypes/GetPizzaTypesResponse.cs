using CodingAssessment.Models.Pagination;

namespace CodingAssessment.Features.PizzaTypes.GetPizzaTypes;

/// <summary>
/// Represents the response containing pizza types and pagination metadata.
/// </summary>
/// <param name="PizzaTypes">The list of pizza types.</param>
/// <param name="Pagination">The pagination metadata.</param>
public record GetPizzaTypesResponse(
    List<PizzaTypeResponse> PizzaTypes, 
    Pagination Pagination
);
