namespace CodingAssessment.Features.OrderDetails.ImportOrderDetails;

/// <summary>
/// Represents a request to import data from a CSV file.
/// </summary>
/// <param name="File">The CSV file to be imported.</param>
public record ImportOrderDetailsRequest(IFormFile File);
