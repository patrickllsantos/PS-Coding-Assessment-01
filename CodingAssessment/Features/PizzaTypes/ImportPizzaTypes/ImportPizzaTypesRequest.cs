namespace CodingAssessment.Features.PizzaTypes.ImportPizzaTypes;

/// <summary>
/// Represents a request to import data from a CSV file.
/// </summary>
/// <param name="File">The CSV file to be imported.</param>
public record ImportPizzaTypesRequest(IFormFile File);
