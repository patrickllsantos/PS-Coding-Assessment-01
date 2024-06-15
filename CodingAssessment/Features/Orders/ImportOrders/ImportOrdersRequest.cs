namespace CodingAssessment.Features.Orders.Import;

/// <summary>
/// Represents a request to import data from a CSV file.
/// </summary>
/// <param name="File">The CSV file to be imported.</param>
public record ImportOrdersRequest(IFormFile File);
