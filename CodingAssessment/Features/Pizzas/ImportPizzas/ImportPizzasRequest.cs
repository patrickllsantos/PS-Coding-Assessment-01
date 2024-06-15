namespace CodingAssessment.Features.Pizzas.Import;

/// <summary>
/// Represents a request to import data from a CSV file.
/// </summary>
/// <param name="File">The CSV file to be imported.</param>
public record ImportPizzasRequest(IFormFile File);
