using MediatR;

namespace CodingAssessment.Features.OrderDetails.ImportOrderDetails;

/// <summary>
/// Represents a command to import data from a CSV file.
/// </summary>
/// <param name="OrderDetailsRequest">The import request containing the CSV file.</param>
public record ImportOrderDetailsCommand(ImportOrderDetailsRequest OrderDetailsRequest) : IRequest<Unit>;